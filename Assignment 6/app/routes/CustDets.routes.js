module.exports = (app) => {
    const CustDets = require('../controllers/CustDets.controllers.js');

    // Create a new 
    app.post('/CustDets', CustDets.create);

    // Retrieve all s
    //app.get('/Users', Customers.findAll);

    // Retrieve a single  specified by Id
    app.get('/CustDets/:fname', CustDets.findOne);

    // Update a  specified by Id
    app.put('/CustDetss/:fname', CustDets.update);

    // Delete a  specified by Id
    app.delete('/CustDets/:fname', CustDets.delete);
}