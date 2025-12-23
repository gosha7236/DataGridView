using Moq;
using Services.Contacts;
using Entities;
using FluentAssertions;
using Moq;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Storage.Tests
{
    public class StorageManagerTests
    {
        /// <summary>
        /// Проверяет, что метод AddItem вызывает AddAsync у хранилища ровно один раз
        /// с тем же объектом Item, который был передан в StorageManager.
        /// </summary>
        [Fact]
        public void AddItemShouldCallStorageAddAsync()
        {
            // -------------------- Arrange --------------------
            var item = CreateItem();

            var storageMock = new Mock<IStorage<Item>>();
            storageMock
                .Setup(s => s.AddAsync(item, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var manager = new StorageManager(storageMock.Object);

            // -------------------- Act --------------------
            manager.AddItem(item);

            // -------------------- Assert --------------------
            storageMock.Verify(
                s => s.AddAsync(item, It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        /// Проверяет, что метод GetAll возвращает коллекцию,
        /// полученную из хранилища без изменений.
        /// </summary>
        [Fact]
        public void GetAllShouldReturnItemsFromStorage()
        {
            // -------------------- Arrange --------------------
            var items = new List<Item>
            {
                CreateItem(),
                CreateItem()
            };

            var storageMock = new Mock<IStorage<Item>>();
            storageMock
                .Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(items);

            var manager = new StorageManager(storageMock.Object);

            // -------------------- Act --------------------
            var result = manager.GetAll();

            // -------------------- Assert --------------------
            result.Should().BeEquivalentTo(items);
        }

        /// <summary>
        /// Проверяет, что метод RemoveItem вызывает DeleteAsync у хранилища
        /// с переданным идентификатором.
        /// </summary>
        [Fact]
        public void RemoveItemShouldCallStorageDeleteAsync()
        {
            // -------------------- Arrange --------------------
            var id = Guid.NewGuid();

            var storageMock = new Mock<IStorage<Item>>();
            storageMock
                .Setup(s => s.DeleteAsync(id, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var manager = new StorageManager(storageMock.Object);

            // -------------------- Act --------------------
            manager.RemoveItem(id);

            // -------------------- Assert --------------------
            storageMock.Verify(
                s => s.DeleteAsync(id, It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        /// Проверяет, что метод UpdateItem вызывает UpdateAsync у хранилища
        /// с обновлённым объектом Item.
        /// </summary>
        [Fact]
        public void UpdateItemShouldCallStorageUpdateAsync()
        {
            // -------------------- Arrange --------------------
            var item = CreateItem();

            var storageMock = new Mock<IStorage<Item>>();
            storageMock
                .Setup(s => s.UpdateAsync(item, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var manager = new StorageManager(storageMock.Object);

            // -------------------- Act --------------------
            manager.UpdateItem(item);

            // -------------------- Assert --------------------
            storageMock.Verify(
                s => s.UpdateAsync(item, It.IsAny<CancellationToken>()),
                Times.Once);
        }

        private static Item CreateItem()

{
            return new Item
            {
                Id = Guid.NewGuid(),
                Name = "Test item",
                Size = "10",
                Price = 100,
                Material = "Plastic",
                Amount = 1
            };
}
    }
}