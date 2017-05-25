var _ = require('lodash');

module.exports = {
    sortBy: function (callback, data, option) {
        var result = _.sortBy(data, [option]);
        callback(null, result);
    }
};