module.exports = (app) => {
    const OrderDets = require('../controllers/OrderDets.controllers.js');


    // Default message for /
    app.get('/', OrderDets.root);

    // Create a new 
    app.post('/OrderDets', OrderDets.create);

    // Retrieve all s
    app.get('/Orders', OrderDets.findAll);

    // Retrieve a single order specified by Id
    app.get('/OrderDets/:orderId',OrderDets.findOne);

    // Update a order specified by Id
    app.put('/OrderDets/:orderId', OrderDets.update);

    // Delete a order specified by Id
    app.delete('/OrderDets/:orderId', OrderDets.delete);

    // Search for Quotations matching s
    app.get('/orderId/:s',OrderDets.searchOrderId); 
    app.get('/phoneId/:s', OrderDets.searchPhoneId);
    app.get('/customerId/:s', OrderDets.searchCustomerId);
}