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
  let list = new TodoList(null, ['item1', 'item2']);

  // Act
  let itemNumber = 1;
  list.done(itemNumber);

  // Assert
  assert.ok(list.items[itemNumber].isDone);
});

QUnit.test('TodoList can load items from server', async function (assert) {
  // Arrange
  let done = assert.async();
  let dataServiceStub = {
    async load() {
      return Promise.resolve(['item1', 'item2']);
    },
  };

  let list = new TodoList(dataServiceStub);

  // Act
  await list.load();

  // Assert
  assert.deepEqual(
    list.items.map((i) => i.name),
    ['item1', 'item2']
  );
  done();
});

QUnit.test('TodoList can save items to server', function (assert) {
  // Arrange
  let savedNames;

  let dataServiceMock = {
    save(names) {
      savedNames = names;
      return Promise.resolve();
    },
  };

  let list = new TodoList(dataServiceMock, ['item1', 'item2']);

  // Act
  list.save();

  // Assert
  assert.deepEqual(savedNames, ['item1', 'item2']);
});
