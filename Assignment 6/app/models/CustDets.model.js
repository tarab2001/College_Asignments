const mongoose = require('mongoose');
// create a mongoose schema for a quotation
const CustSchema = mongoose.Schema({
_id: mongoose.Types.ObjectID(),
title: String,
fname: String,
lname: String,
email: String,
mobile: String,
ShipAdd: Object,
Address: Object
}, {
timestamps: true
});
// export the model to our app
module.exports = mongoose.model('CustDets', CustSchema);