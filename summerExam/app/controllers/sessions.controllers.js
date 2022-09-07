const Session = require('../models/sessions.model.js');


//default message for /get
exports.root = (req,res) => {
    Session.find().then(session => {
        res.render('session_view', {
            results: session
        });
    }).catch(err => {
        res.status(500).send({
            message:err.message || "There was an error while getting all sessions"
        });
    });
};

//search for session matching string on field
exports.searchCleint = (req, res) => {
    var search = req.params.s;
    console.log("Searching client ID: "+search)
    Session.find({ clientId: new RegExp(search,"ig")})
    .then(session => {
        res.render('session_view',{
            results: session
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all clients."
        });
    });
};

// search for session matching string on field
exports.searchDate = (req, res) => {
    var search = req.params.s;
    console.log("Searching session date: "+search)
    Session.find({ seesionDate: new RegExp(search,"ig")})
    .then(session => {
        res.render('session_view',{
            results: session
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all session dates"
        });
    });
};

// search for session matching string field
exports.searchType = (req, res) => {
    var search = req.params.s;
    console.log("Searching session type: "+search)
    Session.find({ type: new RegExp(search,"ig")})
    .then(session => {
        res.render('session_view',{
            results: session
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all session types"
        });
    });
};

// search for session matching certain string
exports.searchPhysio = (req, res) => {
    var search = req.params.s;
    console.log("Searching physio ID: "+search)
    Session.find({ physioId: new RegExp(search,"ig")})
    .then(session => {
        res.render('session_view',{
            results: session
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all physios"
        });
    });
};

// search for session matching certain field
exports.searchTime = (req, res) => {
    var search = req.params.s;
    console.log("Searching session time: "+search)
    Session.find({ sessionTime: new RegExp(search,"ig")})
    .then(session => {
        res.render('session_view',{
            results: session
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all session times"
        });
    });
};


//C(reate) add session to collection
exports.create = (req,res) => {
    //validate request
    if(!req.body.sessionDate||!req.body.sessionTime||!req.body.cleint||!req.body.physio||!req.body.fee||!req.body.sessionNum||!req.body.duration||!req.body.type||!req.body.notes){
        return res.status(400).send({
            message: "Fields can't be empty!!"
        });
    }

    //create session
    const session = new SessionRect({
        sessionDate: req.body.sessionDate,
        sessionTime: req.body.sessionTime,
        clientId: req.body.clientId,
        physioId: req.body.physioId,
        fee: req.body.fee,
        sessionNum: req.body.sessionNum,
        duration: req.body.duration,
        type: req.body.type,
        notes: req.body.notes
    });

    //save new session to db
    session.save().then(date => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.messgae || "Error while creating new session"
        });
    });
};

// R(etrieve) all sessions in the database
exports.findAll = (req, res) => {
    Session.find()
    .then(session => {
        res.send(session);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Error while retrieving all sessions"
        });
    });
};

//R(etrieve) single session by cleint ID
exports.findOne = (req, res) => {
    Session.findByClient(req.params.clientId)
    .then(session => {
        if(!session) {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });            
        }
        res.send(session);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });                
        }
        return res.status(500).send({
            message: "Error retrieving session with client ID " + req.params.clientId
        });
    });
};

//U(pdate) a session with the client ID in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "Session content cannot be empty"
        });
    }

    // Find the session and update it with the request body
    Session.findByClientAndUpdate(req.params.client, {
        sessionDate: req.body.sessionDate,
        sessionTime: req.body.sessionTime,
        clientId: req.body.clientId,
        physioId: req.body.physioId,
        fee: req.body.fee,
        sessionNum: req.body.sessionNum,
        duration: req.body.duration,
        type: req.body.type,
        notes: req.body.notes
    }, 
       { new: true })  // "new: true" return updated object
    .then(session => {
        if(!session) {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });
        }
        res.send(session);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });                
        }
        return res.status(500).send({
            message: "Error updating session with client ID " + req.params.clientId
        });
    });
};

// Update a session identified by the client in the request
exports.updateSession = (req, res) => {
    // Validate Request
    if(!req.body.session) {
        return res.status(400).send({
            message: "Session content cannot be empty"
        });
    }

    // Find the session and update it with the request body
    Session.findByClientIDAndUpdate(req.params.client, {
        clientId: req.body.clientId
    }, 
       { new: true })  // "new: true" return updated object
    .then(session => {
        if(!session) {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });
        }
        res.send(session);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });                
        }
        return res.status(500).send({
            message: "Error updating session with client ID " + req.params.clientId
        });
    });
};



//D(delete) client identified by id
exports.delete = (req, res) => {
    Session.findByClientIDAndRemove(req.params.client)
    .then(session => {
        if(!session) {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });
        }
        res.send({message: "Session deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Session not found with client ID " + req.params.clientId
            });                
        }
        return res.status(500).send({
            message: "Could not delete session with client ID " + req.params.clientId
        });
    });
};
