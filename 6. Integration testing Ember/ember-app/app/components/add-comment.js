import Ember from 'ember';

export default Ember.Component.extend({
  actions: {
    save() {
      const author = this.get('author');
      const text = this.get('text');
      this.get('save')({ author, text });
    }
  }
});
