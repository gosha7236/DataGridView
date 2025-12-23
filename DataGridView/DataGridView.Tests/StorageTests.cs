using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using FluentAssertions;
using Services;
using Xunit;

namespace DataGridView.Tests
{
    public class StorageTests
    {
        private readonly Storage _storage;
        private readonly CancellationToken _ct = CancellationToken.None;

        public StorageTests()
        {
            _storage = new Storage();
        }

        [Fact]
        public async Task GetAllAsync_WhenStorageIsEmpty_ReturnsEmptyList()
        {
            var result = await _storage.GetAllAsync(_ct);

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task AddAsync_AddsItemToStorage()
        {
            var item = CreateItem();

            await _storage.AddAsync(item, _ct);
            var result = await _storage.GetAllAsync(_ct);

            result.Should().ContainSingle();
            result.First().Id.Should().Be(item.Id);
        }

        [Fact]
        public async Task DeleteAsync_WhenItemExists_RemovesItem()
        {
            var item = CreateItem();
            await _storage.AddAsync(item, _ct);

            await _storage.DeleteAsync(item.Id, _ct);
            var result = await _storage.GetAllAsync(_ct);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task DeleteAsync_WhenItemDoesNotExist_DoesNothing()
        {
            var item = CreateItem();
            await _storage.AddAsync(item, _ct);

            await _storage.DeleteAsync(Guid.NewGuid(), _ct);
            var result = await _storage.GetAllAsync(_ct);

            result.Should().ContainSingle();
        }

        [Fact]
        public async Task UpdateAsync_WhenItemExists_UpdatesItem()
        {
            var item = CreateItem();
            await _storage.AddAsync(item, _ct);

            var updatedItem = new Item
            {
                Id = item.Id,
                Size = "99",
                Price = 1000,
                Material = "Steel",
                Amount = 10
            };

            await _storage.UpdateAsync(updatedItem, _ct);
            var result = (await _storage.GetAllAsync(_ct)).First();

            result.Size.Should().Be("99");
            result.Price.Should().Be(1000);
            result.Material.Should().Be("Steel");
            result.Amount.Should().Be(10);
        }

        [Fact]
        public async Task UpdateAsync_WhenItemDoesNotExist_DoesNothing()
        {
            var item = CreateItem();
            await _storage.AddAsync(item, _ct);

            var nonExistingItem = CreateItem();

            await _storage.UpdateAsync(nonExistingItem, _ct);
            var result = (await _storage.GetAllAsync(_ct)).First();

            result.Id.Should().Be(item.Id);
        }

        private static Item CreateItem()
        {
            return new Item
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Size = "10",
                Price = 100,
                Material = "Plastic",
                Amount = 1
            };
        }
    }
}