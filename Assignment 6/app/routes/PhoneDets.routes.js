module.exports = (app) => {
    const PhoneDets = require('../controllers/PhoneDets.controllers.js');

    // Create a new 
    app.post('/PhoneDets', PhoneDets.create);

    // Retrieve all s
    //app.get('/Phone', Phone.findAll);

    // Retrieve a single  specified by Id
    app.get('/PhoneDets/:model', PhoneDets.findOne);

    // Update a  specified by Id
    app.put('/PhoneDets/:model', PhoneDets.update);

    // Delete a  specified by Id
    app.delete('/PhoneDets/:model', PhoneDets.delete);
}