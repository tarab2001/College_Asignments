module.exports = (app) => {
    const sessions = require('../controllers/sessions.controllers.js');


    // Default message for /
    app.get('/', sessions.root);

    // Create a new session
    app.post('/sessions', sessions.create);

    // Retrieve all sessions
    app.get('/sessions', sessions.findAll);

    // Retrieve a single session specified by client ID
    app.get('/sessions/:clientId', sessions.findOne);

    // Update a session by client ID
    app.put('/sessions/:clientId', sessions.update);

     // Update a session clients name field specified by client ID
     app.put('/sessions/clientId/:clientId', sessions.updateSession);

    // Delete a session specified by client name
    app.delete('/sessions/:clientId', sessions.delete);

    // Search for clients matching s
    app.get('/client/:s',sessions.searchClient); 
    app.get('/sessionDate/:s', sessions.searchDate);
    app.get('/type/:s', sessions.searchType);
    app.get('/physio/:s', sessions.searchPhysio);
    app.get('/sessionTime/:s', sessions.searchTime);
}