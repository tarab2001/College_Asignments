module.exports = (app) => {
    const physios = require('../controllers/physios.controllers.js');


    // Default message for /
    app.get('/', physios.root);

    // Create a new physio 
    app.post('/physios', physios.create);

    // Retrieve all physios
    app.get('/physios', physios.findAll);

    // Retrieve a single physio specified by first name
    app.get('/physios/:fname', physios.findOne);

    // Update a physio by first name
    app.put('/physios/:fname', physios.update);

     // Update a physios first name field specified by first name
     app.put('/physios/fname/:fname', physios.updatePhysio);

    // Delete a physio specified by first name
    app.delete('/physios/:fname', physios.delete);

    // Search for physios matching s
    app.get('/fname/:s',physios.searchFirstName); 
    app.get('/lname/:s', physios.searchLastName);
    app.get('/email/:s', physios.searchEmail);
    app.get('/mobile/:s', physios.searchMobile);
    app.get('/homePhone/:s', physios.searchHomePhone);
    app.get('/line1/:s', physios.searchAddress);
}