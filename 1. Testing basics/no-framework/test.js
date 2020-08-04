import TodoList from './todo-list.js';

function todoListCanAddItem() {
  // Arrange
  let list = new TodoList();

  //Act
  let itemName = 'test';
  list.addItem(itemName);

  //Assert
  if (!list.items.some((item) => item.name == itemName)) {
    throw 'todoListCanAddItem - ERROR';
  }
}

function todoListCanCheckItem() {
  // Arrange
  let list = new TodoList(['item1', 'item2']);

  //Act
  let itemNumber = 1;
  list.done(itemNumber);

  //Assert
  if (!list.items[itemNumber].isDone) {
    throw 'todoListCanCheckItem - ERROR';
  }
}

todoListCanAddItem();
todoListCanCheckItem();
