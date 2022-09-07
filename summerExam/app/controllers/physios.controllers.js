const Physio = require('../models/physios.model.js');


//default message for /get
exports.root = (req,res) => {
    Physio.find().then(physio => {
        res.render('physio_view', {
            results: physio
        });
    }).catch(err => {
        res.status(500).send({
            message:err.message || "There was an error while getting all physios"
        });
    });
};

//search for physio matching string on field
exports.searchFirstName = (req, res) => {
    var search = req.params.s;
    console.log("Searching first name: "+search)
    Physio.find({ fname: new RegExp(search,"ig")})
    .then(physio => {
        res.render('physio_view',{
            results: physio
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all first names."
        });
    });
};

// search for physio matching string on field
exports.searchLastName = (req, res) => {
    var search = req.params.s;
    console.log("Searching last name: "+search)
    Physio.find({ lname: new RegExp(search,"ig")})
    .then(physio => {
        res.render('physio_view',{
            results: physio
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all last names"
        });
    });
};

// search for physio matching string field
exports.searchEmail = (req, res) => {
    var search = req.params.s;
    console.log("Searching email: "+search)
    Physio.find({ email: new RegExp(search,"ig")})
    .then(physio => {
        res.render('physio_view',{
            results: physio
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all emails"
        });
    });
};

// search for physio matching certain string
exports.searchMobile = (req, res) => {
    var search = req.params.s;
    console.log("Searching mobile: "+search)
    Physio.find({ mobile: new RegExp(search,"ig")})
    .then(physio => {
        res.render('physio_view',{
            results: physio
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all mobiles"
        });
    });
};

// search for physio matching certain field
exports.searchHomePhone = (req, res) => {
    var search = req.params.s;
    console.log("Searching home phone: "+search)
    Physio.find({ homePhone: new RegExp(search,"ig")})
    .then(physio => {
        res.render('physio_view',{
            results: physio
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all home phones"
        });
    });
};

// search for physio matching string
exports.searchAddress = (req, res) => {
    var search = req.params.s;
    console.log("Searching shipping address: "+search)
    Physio.find({ line1: new RegExp(search,"ig")})
    .then(physio => {
        res.render('physio_view',{
            results: physio
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "There was an error while getting all addresses"
        });
    });
};

//C(reate) add physio to collection
exports.create = (req,res) => {
    //validate request
    if(!req.body.fname||!req.body.lname||!req.body.mobile||!req.body.homePhone||!req.body.email||!req.body.line1||!req.body.town||!req.body.cityOrCounty){
        return res.status(400).send({
            message: "Fields can't be empty!!"
        });
    }

    //create physio
    const physio = new PhysioRect({
        title: req.body.title,
        fname: req.body.fname,
        lname: req.body.lname,
        mobile: req.body.mobile,
        homePhone: req.body.homePhone,
        email: req.body.email,
        line1: req.body.line1,
        line2: req.body.line2,
        town: req.body.town,
        EIRCODE: req.body.EIRCODE
    });

    //save new physio to db
    physio.save().then(date => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.messgae || "Error while creating new physio"
        });
    });
};

// R(etrieve) all Physios in the database
exports.findAll = (req, res) => {
    Physio.find()
    .then(physio => {
        res.send(physio);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Error while retrieving all physios"
        });
    });
};

//R(etrieve) single physio by first name
exports.findOne = (req, res) => {
    Physio.findById(req.params.fname)
    .then(physio => {
        if(!physio) {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });            
        }
        res.send(physio);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error retrieving Physio with first name " + req.params.fname
        });
    });
};

//U(pdate) a physio with the first name in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "Physio content cannot be empty"
        });
    }

    // Find the physio and update it with the request body
    Physio.findByFnameAndUpdate(req.params.fname, {
        title: req.body.title,
        fname: req.body.fname,
        lname: req.body.lname,
        mobile: req.body.mobile,
        homePhone: req.body.homePhone,
        email: req.body.email,
        line1: req.body.line1,
        line2: req.body.line2,
        town: req.body.town,
        EIRCODE: req.body.EIRCODE
    }, 
       { new: true })  // "new: true" return updated object
    .then(physio => {
        if(!physio) {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });
        }
        res.send(physio);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error updating Physio with first name " + req.params.fname
        });
    });
};

// Update a physio identified by the first name in the request
exports.updatePhysio = (req, res) => {
    // Validate Request
    if(!req.body.physio) {
        return res.status(400).send({
            message: "Physio content cannot be empty"
        });
    }

    // Find the physio and update it with the request body
    Physio.findByFnameAndUpdate(req.params.fname, {
        fname: req.body.fname
    }, 
       { new: true })  // "new: true" return updated object
    .then(physio => {
        if(!physio) {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });
        }
        res.send(physio);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error updating physio with first name " + req.params.fname
        });
    });
};



//D(delete) physio identified by fname
exports.delete = (req, res) => {
    Physio.findByFnameAndRemove(req.params.fname)
    .then(physio => {
        if(!physio) {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });
        }
        res.send({message: "Physio deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Physio not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Could not delete physio with first name " + req.params.fname
        });
    });
};
