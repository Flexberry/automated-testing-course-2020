import Ember from 'ember';

export default Ember.Route.extend({
  actions: {
    showError(errorMessage) {
      this.set('controller.errorMessage', errorMessage);
    }
  }
});
