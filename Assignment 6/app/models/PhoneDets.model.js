const mongoose = require('mongoose');
// create a mongoose schema for a quotation
const PhoneSchema = mongoose.Schema({
_id: mongoose.Types.ObjectID(),
manufactuer: String,
model: String,
price:String
}, {
timestamps: true
});
// export the model to our app
module.exports = mongoose.model('PhoneDets', PhoneSchema);