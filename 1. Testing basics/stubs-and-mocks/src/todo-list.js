const { TodoItem } = require('./todo-item.js');
const { DataService } = require('./todo-item.js');

class TodoList {
  constructor(dataService, names = []) {
    this.dataService = dataService;
    this.items = names.map((name) => new TodoItem(name));
  }

  async load() {
    // let dataService = new DataService('http://localhost:3000'); // Bad way!!
    let names = await this.dataService.load();
    this.items = names.map((name) => new TodoItem(name));
  }

  save() {
    let names = this.items.filter((item) => !item.isDone).map((item) => item.name);
    return this.dataService.save(names);
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
