const express = require('express');
const bodyParser = require('body-parser');
const app = express();

const hbs = require('hbs');
const path = require('path');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}))

//require('./app/routes/CustDets.routes')(app);
//require('./app/routes/OrderDets.routes')(app);
//require('./app/routes/PhoneDets.routes')(app);

app.set('views', path.join(_dirname, 'views'));
app.set('view engine', 'hbs');
app.use('/assets', express.static(_dirname + '/public'));

const dbConnect = require('./connect.js');
const mogoose = require('mongoose');

mongoose.connect(dbConnect.database.url, {
    useNewUrlParser: true,
    useUnifiedTopology: true
    }).then(() => {
    console.log("Successfully connected to the MongoDB database");
    }).catch(err => {
    console.log('Unable to connect to the MongoDB database', err);
    process.exit();
});
app.listen(3000, () => {
    comsole.log("Server listening")
});