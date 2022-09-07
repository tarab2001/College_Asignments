module.exports = (app) => {
    const clients = require('../controllers/clients.controllers.js');


    // Default message for /
    app.get('/', clients.root);

    // Create a new clients 
    app.post('/clients', clients.create);

    // Retrieve all clients
    app.get('/clients', clients.findAll);

    // Retrieve a single client specified by first name
    app.get('/clients/:fname', clients.findOne);

    // Update a clientby first name
    app.put('/clients/:fname', clients.update);

     // Update a clients first name field specified by first name
     app.put('/clients/fname/:fname', clients.updateClient);

    // Delete a client specified by first name
    app.delete('/clients/:fname', clients.delete);

    // Search for clients matching s
    app.get('/fname/:s',clients.searchFirstName); 
    app.get('/lname/:s', clients.searchLastName);
    app.get('/email/:s', clients.searchEmail);
    app.get('/mobile/:s', clients.searchMobile);
    app.get('/homePhone/:s', clients.searchHomePhone);
    app.get('/line1/:s', clients.searchAddress);
    app.get('/DOB/:s', clients.searchDOB);
}