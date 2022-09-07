module.exports = (app) => {
    const CustDets = require('../controllers/CustDets.controllers.js');


    // Default message for /
    app.get('/', CustDets.root);

    // Create a new 
    app.post('/CustDets', CustDets.create);

    // Retrieve all s
    app.get('/CustDets', CustDets.findAll);

    // Retrieve a single customer specified by first name
    app.get('/CustDets/:fname', CustDets.findOne);

    // Update a  specified by Id
    app.put('/CustDets/:fname', CustDets.update);

     // Update a Quotation's quotation field specified by quotationId
     app.put('/CustDets/fname/:fname', CustDets.updateCust);

    // Delete a  specified by Id
    app.delete('/CustDets/:customerId', CustDets.delete);

    // Search for Quotations matching s
    app.get('/fname/:s',CustDets.searchFirstName); 
    app.get('/lname/:s', CustDets.searchLastName);
    app.get('/email/:s', CustDets.searchEmail);
    app.get('/mobile/:s', CustDets.searchMobile);
    app.get('/address/:s', CustDets.searchAddress);
    app.get('/ShipAdd/:s', CustDets.searchShipAddress);
}