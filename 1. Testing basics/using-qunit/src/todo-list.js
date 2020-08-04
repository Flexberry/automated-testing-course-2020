const { TodoItem } = require('./todo-item.js');

class TodoList {
  constructor(names = []) {
    this.items = names.map((name) => new TodoItem(name));
  }

  addItem(name) {
    this.items.push(new TodoItem(name));
  }

  done(index) {
    this.items[index].done();
  }

  clear() {
    this.items = this.items.filter((item) => !item.isDone);
  }
}

module.exports = { TodoList };
