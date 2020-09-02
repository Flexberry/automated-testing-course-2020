import Ember from 'ember';
export default function sum(a, b, delay) {
  const result = a + b;

  if (delay === 1001) {
    return Ember.RSVP.reject();
  }

  if (delay) {
    return new Ember.RSVP.Promise((resolve) => {
      Ember.run.later(resolve, result, delay);
    });
  }

  return result;
}
