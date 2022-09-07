const mongoose = require('mongoose');

//create mongoose schema for sessions
const SessionSchema = mongoose.Schema({
    sessionDate: {String, required:true},
    sessionTime: {String, required:true},
    clientId: {String, required:true},
    physioId: {String, required:true},
    fee: {String, required:true},
    sessionNum: {String, required:true},
    duration: {String, required:true},
    type: {String, required:false},
    notes: {String, required:true}
})