import Ember from 'ember';
import DS from 'ember-data';

export default DS.Model.extend({
  name: DS.attr('string'),
  surname: DS.attr('string'),
  fullName: Ember.computed('name', 'surname', function () {
    return `${this.get('name')} ${this.get('surname')}`;
  }),
});
