const Phone = require('../models/PhoneDets.model.js');

// Default message for / (get)
exports.root = (req, res) => {
    Phone.find()
    .then(phone => {
        res.render('phones_view',{
            results: phone
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Phone."
        });
    });
};

// search for quotations, matching string on quote field
exports.searchManufactuer = (req, res) => {
    var search = req.params.s;
    console.log("Searching Manufactuer: "+search)
    Phone.find({ manufactuer: new RegExp(search,"ig")})
    .then(phone => {
        res.render('phones_view',{
            results: phone
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Phone."
        });
    });
};

// search for quotations, matching string on quote field
exports.searchModel = (req, res) => {
    var search = req.params.s;
    console.log("Searching model: "+search)
    Phone.find({ model: new RegExp(search,"ig")})
    .then(phone => {
        res.render('phones_view',{
            results: phone
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Phone."
        });
    });
};

// search for phones, matching string on quote field
exports.searchPrice = (req, res) => {
    var search = req.params.s;
    console.log("Searching price: "+search)
    Phone.find({ price: new RegExp(search,"ig")})
    .then(phone => {
        res.render('phones_view',{
            results: phone
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Phone."
        });
    });
};

// Create a new Order and save to the database
// Create and Save a new Order
exports.create = (req, res) => {
    // Validate the request
    if(!req.body.manufactuer || !req.body.model || !req.body.price) {
        return res.status(400).send({
            message: "Phone content cannot be empty!"
        });
    }

    // Create a new phone (using schema)
    const phone = new Phone({
        manufactuer: req.body.manufactuer,
        model: req.body.model,
        price: req.body.price
    });

    // Save phone in the database
    phone.save()
    .then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while creating the Phone."
        });
    });
};

// Return all phones in the database
exports.findAll = (req, res) => {
    Phone.find()
    .then(phone => {
        res.send(phone);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Phones."
        });
    });
};

// Find a single phone identified by model
exports.findOne = (req, res) => {
    Phone.findByModel(req.params.model)
    .then(phone => {
        if(!phone) {
            return res.status(404).send({
                message: "Phone not found with model " + req.params.model
            });            
        }
        res.send(phone);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Phone not found with model " + req.params.model
            });                
        }
        return res.status(500).send({
            message: "Error retrieving Phone with model " + req.params.model
        });
    });
};

// Update a phone identified by the model in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "Phone content cannot be empty"
        });
    }

    // Find the phone and update it with the request body
    Phone.findByIdAndUpdate(req.params.model, {
        manufactuer: req.body.manufactuer, 
        model: req.body.model,
        price: req.body.price
    }, 
       { new: true })  // "new: true" return updated object
    .then(phone => {
        if(!phone) {
            return res.status(404).send({
                message: "Phone not found with model " + req.params.model
            });
        }
        res.send(phone);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Phone not found with model " + req.params.model
            });                
        }
        return res.status(500).send({
            message: "Error updating Phone with model " + req.params.model
        });
    });
};

// Update a phone identified by the model in the request
exports.updatePhone = (req, res) => {
    // Validate Request
    if(!req.body.phone) {
        return res.status(400).send({
            message: "Phone content cannot be empty"
        });
    }

    // Find the phone and update it with the request body
    Phone.findByIdAndUpdate(req.params.model, {
        model: req.body.model
    }, 
       { new: true })  // "new: true" return updated object
    .then(phone => {
        if(!phone) {
            return res.status(404).send({
                message: "Phone not found with model " + req.params.model
            });
        }
        res.send(phone);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Phone not found with model " + req.params.model
            });                
        }
        return res.status(500).send({
            message: "Error updating Phone with model " + req.params.model
        });
    });
};



// Delete a phone identified by phoneId
exports.delete = (req, res) => {
    Phone.findByIdAndRemove(req.params.phoneId)
    .then(phone => {
        if(!phone) {
            return res.status(404).send({
                message: "Phone not found with id " + req.params.phoneId
            });
        }
        res.send({message: "Phone deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Phone not found with id " + req.params.phoneId
            });                
        }
        return res.status(500).send({
            message: "Could not delete Phone with id " + req.params.phoneId
        });
    });
};