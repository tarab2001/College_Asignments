module.exports = (app) => {
    const PhoneDets = require('../controllers/PhoneDets.controllers.js');


    // Default message for /
    app.get('/', PhoneDets.root);

    // Create a new 
    app.post('/PhoneDets', PhoneDets.create);

    // Retrieve all s
    app.get('/PhoneDets', Phone.findAll);

    // Retrieve a single phone specified by model
    app.get('/PhoneDets/:model', PhoneDets.findOne);

    // Update a phone specified by model
    app.put('/PhoneDets/:model', PhoneDets.update);

    // Delete a phone specified by Id
    app.delete('/PhoneDets/:phoneId', PhoneDets.delete);

    // Search for Quotations matching s
    app.get('/manufactuer/:s',PhoneDets.searchManufactuer); 
    app.get('/model/:s', PhoneDets.searchModel);
    app.get('/price/:s', PhoneDets.searchPrice);
}