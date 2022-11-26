import mock from './mock';

const data = [{ ...}];

mock.onGet('/url/get-data').reply(config => {
  return [200, data]
})
