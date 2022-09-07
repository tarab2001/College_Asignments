const mongoose = require('mongoose');

//create mongoose schema for cleints
const ClientSchema = mongoose.Schema({
    title: {String, required:true},
    fname: {String, required:true},
    lname: {String, required:true},
    mobile: {String, required:true},
    homePhone: {String, required:true},
    email: {String, required:true},
    line1: {String, required:true},
    line2: {String, required:false},
    town: {String, required:true},
    cityOrCounty: {String, required:true},
    EIRCODE: {String, required:false},
    DOB: {String, required:true},
    parentOrGaurdian: {String, required:true},
   leaveMessage: {String, required:true},
    dateofrecord: {String, required:true},
    referredBy: {String, required:true}
})