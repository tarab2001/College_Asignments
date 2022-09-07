module.exports = (app) => {
    const OrderDets = require('../controllers/OrderDets.controllers.js');

    // Create a new 
    app.post('/OrderDets', OrderDets.create);

    // Retrieve all s
    //app.get('/Orders', Orders.findAll);

    // Retrieve a single  specified by Id
    app.get('/OrderDets/:_id',OrderDets.findOne);

    // Update a  specified by Id
    app.put('/OrderDets/:_id', OrderDets.update);

    // Delete a  specified by Id
    app.delete('/OrderDets/:_id', OrderDets.delete);
}