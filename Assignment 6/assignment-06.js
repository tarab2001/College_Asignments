//tested using Windows OS and Chrome 
//all code used is based off John's examples

const express = require('express'); // we're making an ExpressJS App
const bodyParser = require('body-parser'); // we'll use body-parser extensively
const app = express(); // create the ExpressJS app
// parse the different kinds of requests (content-type) the app handles
// use the "use" method to set up the body-parser middlewear
app.use(bodyParser.json()) // application/json
app.use(bodyParser.urlencoded({ extended: true })) // application/x-www-form-urlencoded

// Set up Mongoose and our Database connection
const dbConnect = require('./connect.js');
const mongoose = require('mongoose');
// Set up connection to the database
mongoose.connect(dbConnect.database.url, {
useNewUrlParser: true,
useUnifiedTopology: true
}).then(() => {
console.log("Successfully connected to the MongoDB database");
}).catch(err => {
console.log('Unable to connect to the MongoDB database', err);
process.exit();
});


// create our test route (reply by sending a JSON message as response)
app.get('/', (req, res) => {
res.json({"message": "Phone Store."})
});
// listen for requests on port 3000
app.listen(3000, () => {
console.log("Server listening on port 3000");
});