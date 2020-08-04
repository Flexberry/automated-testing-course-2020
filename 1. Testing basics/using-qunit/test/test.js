const { TodoList } = require('../src/todo-list.js');

QUnit.module('TodoList');

QUnit.test('TodoList can add item', function (assert) {
  // Arrange
  assert.expect(0);
  let list = new TodoList();

  // Act
  let itemName = 'test';
  list.addItem(itemName);

  // Assert

  // Check test result without assert object calling.
  if (!list.items.some((item) => item.name == itemName)) {
    throw 'todoListCanAddItem - ERROR';
  }
});

QUnit.test('TodoList can check item', function (assert) {
  // Arrange
  let list = new TodoList(['item1', 'item2']);

  // Act
  let itemNumber = 1;
  list.done(itemNumber);

  // Assert
  assert.ok(list.items[itemNumber].isDone);
});
