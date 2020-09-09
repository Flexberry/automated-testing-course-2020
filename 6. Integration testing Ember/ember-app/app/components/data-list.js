import Ember from 'ember';

export default Ember.Component.extend({
  data: Ember.inject.service(),
  actions: {
    load() {
      this.get('data').getAll().then((allData) => {
        this.set('allData', allData);
      });
    }
  }
});
