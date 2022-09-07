const Client = require('../models/clients.model.js');


//default message for /get
exports.root = (req,res) => {
    Client.find().then(clients => {
        res.render('client_view', {
            results: clients
        });
    }).catch(err => {
        res.status(500).send({
            message:err.message || "There was an error while getting all clients"
        });
    });
};

//search for client matching string on field
exports.searchFirstName = (req, res) => {
    var search = req.params.s;
    console.log("Searching first name: "+search)
    Clients.find({ fname: new RegExp(search,"ig")})
    .then(client => {
        res.render('client_view',{
            results: client
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all first names."
        });
    });
};

// search for client matching string on field
exports.searchLastName = (req, res) => {
    var search = req.params.s;
    console.log("Searching last name: "+search)
    Client.find({ lname: new RegExp(search,"ig")})
    .then(client => {
        res.render('client_view',{
            results: client
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all last names"
        });
    });
};

// search for client matching string field
exports.searchEmail = (req, res) => {
    var search = req.params.s;
    console.log("Searching email: "+search)
    Client.find({ email: new RegExp(search,"ig")})
    .then(client => {
        res.render('client_view',{
            results: client
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all emails"
        });
    });
};

// search for client matching certain string
exports.searchMobile = (req, res) => {
    var search = req.params.s;
    console.log("Searching mobile: "+search)
    Client.find({ mobile: new RegExp(search,"ig")})
    .then(client => {
        res.render('client_view',{
            results: client
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all mobiles"
        });
    });
};

// search for clients matching certain field
exports.searchHomePhone = (req, res) => {
    var search = req.params.s;
    console.log("Searching home phone: "+search)
    Client.find({ homePhone: new RegExp(search,"ig")})
    .then(client => {
        res.render('client_view',{
            results: client
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all home phones"
        });
    });
};

// search for client matching string
exports.searchAddress = (req, res) => {
    var search = req.params.s;
    console.log("Searching shipping address: "+search)
    Client.find({ line1: new RegExp(search,"ig")})
    .then(client => {
        res.render('client_view',{
            results: client
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all addresses"
        });
    });
};

// search for client matching string
exports.searchDOB = (req, res) => {
    var search = req.params.s;
    console.log("Searching date of birth: "+search)
    Client.find({ DOB: new RegExp(search,"ig")})
    .then(client => {
        res.render('client_view',{
            results: client
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all date of births"
        });
    });
};

//C(reate) add clients to collection
exports.create = (req,res) => {
    //validate request
    if(!req.body.fname||!req.body.lname||!req.body.mobile||!req.body.homePhone||!req.body.email||!req.body.line1||!req.body.town||!req.body.cityOrCounty||!req.body.DOB||!req.body.parentOrGaurdian||!req.body.leavemessage||!req.body.dateofrecord||!req.body.doctor||!req.body.referredBy){
        return res.status(400).send({
            message: "Fields can't be empty!!"
        });
    }

    //create client
    const client = new ClientRect({
        title: req.body.title,
        fname: req.body.fname,
        lname: req.body.lname,
        mobile: req.body.mobile,
        homePhone: req.body.homePhone,
        email: req.body.email,
        line1: req.body.line1,
        line2: req.body.line2,
        town: req.body.town,
        EIRCODE: req.body.EIRCODE,
        DOB: req.body.DOB,
        parentOrGaurdian: req.body.parentOrGaurdian,
        leavemessage: req.body.leavemessage,
        dateofrecord: req.body.dateofrecord,
        doctor: req.body.doctor,
        referredBy: req.body.referredBy
    });

    //save new client to db
    client.save().then(date => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.messgae || "Error while creating new client"
        });
    });
};

// R(etrieve) all Customers in the database
exports.findAll = (req, res) => {
    Client.find()
    .then(client => {
        res.send(client);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Error while retrieving all clients"
        });
    });
};

//R(etrieve) single client by first name
exports.findOne = (req, res) => {
    Client.findById(req.params.fname)
    .then(client => {
        if(!client) {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });            
        }
        res.send(client);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error retrieving Client with first name " + req.params.fname
        });
    });
};

//U(pdate) a client with the first name in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "Client content cannot be empty"
        });
    }

    // Find the client and update it with the request body
    Client.findByFnameAndUpdate(req.params.fname, {
        title: req.body.title,
        fname: req.body.fname,
        lname: req.body.lname,
        mobile: req.body.mobile,
        homePhone: req.body.homePhone,
        email: req.body.email,
        line1: req.body.line1,
        line2: req.body.line2,
        town: req.body.town,
        EIRCODE: req.body.EIRCODE,
        DOB: req.body.DOB,
        parentOrGaurdian: req.body.parentOrGaurdian,
        leavemessage: req.body.leavemessage,
        dateofrecord: req.body.dateofrecord,
        doctor: req.body.doctor,
        referredBy: req.body.referredBy
    }, 
       { new: true })  // "new: true" return updated object
    .then(client => {
        if(!client) {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });
        }
        res.send(client);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error updating Client with first name " + req.params.fname
        });
    });
};

// Update a client identified by the first name in the request
exports.updateClient = (req, res) => {
    // Validate Request
    if(!req.body.client) {
        return res.status(400).send({
            message: "Client content cannot be empty"
        });
    }

    // Find the client and update it with the request body
    Client.findByFnameAndUpdate(req.params.fname, {
        fname: req.body.fname
    }, 
       { new: true })  // "new: true" return updated object
    .then(client => {
        if(!client) {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });
        }
        res.send(customer);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error updating client with first name " + req.params.fname
        });
    });
};



//D(delete) client identified by fname
exports.delete = (req, res) => {
    Client.findByFnameAndRemove(req.params.fname)
    .then(client => {
        if(!client) {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });
        }
        res.send({message: "Client deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Client not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Could not delete client with firdt name " + req.params.fname
        });
    });
};
