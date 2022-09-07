const mongoose = require('mongoose');
// create a mongoose schema for a quotation
const OrderSchema = mongoose.Schema({
_id: mongoose.Types.ObjectID(),
user_id: mongoose.Types.ObjectID(),
phone_id: mongoose.Types.ObjectID()
}, {
timestamps: true
});
// export the model to our app
module.exports = mongoose.model('OrderDets', OrderSchema);