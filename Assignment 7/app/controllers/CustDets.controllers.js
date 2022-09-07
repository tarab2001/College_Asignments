const Customer = require('../models/CustDets.model.js');

// Default message for / (get)
exports.root = (req, res) => {
    Customer.find()
    .then(customer => {
        res.render('customers_view',{
            results: customer
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// search for Customers, matching string on quote field
exports.searchFirstName = (req, res) => {
    var search = req.params.s;
    console.log("Searching first name: "+search)
    Customer.find({ fname: new RegExp(search,"ig")})
    .then(customer => {
        res.render('customers_view',{
            results: customer
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// search for Customer, matching string on author field
exports.searchLastName = (req, res) => {
    var search = req.params.s;
    console.log("Searching last name: "+search)
    Customer.find({ lname: new RegExp(search,"ig")})
    .then(customer => {
        res.render('customers_view',{
            results: customer
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// search for Customer, matching string on author field
exports.searchEmail = (req, res) => {
    var search = req.params.s;
    console.log("Searching email: "+search)
    Customer.find({ email: new RegExp(search,"ig")})
    .then(customer => {
        res.render('customers_view',{
            results: customer
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// search for Customer, matching string on author field
exports.searchMobile = (req, res) => {
    var search = req.params.s;
    console.log("Searching mobile: "+search)
    Customer.find({ mobile: new RegExp(search,"ig")})
    .then(customer => {
        res.render('customers_view',{
            results: customer
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// search for Customer, matching string on author field
exports.searchAddress = (req, res) => {
    var search = req.params.s;
    console.log("Searching billing address: "+search)
    Customer.find({ address: new RegExp(search,"ig")})
    .then(customer => {
        res.render('customers_view',{
            results: customer
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// search for Customer, matching string on author field
exports.searchShipAddress = (req, res) => {
    var search = req.params.s;
    console.log("Searching shipping address: "+search)
    Customer.find({ ShipAdd: new RegExp(search,"ig")})
    .then(customer => {
        res.render('customers_view',{
            results: customer
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// Create a new Customer and save to the database
// Create and Save a new Customer
exports.create = (req, res) => {
    // Validate the request
    if(!req.body.customer || !req.body.fname) {
        return res.status(400).send({
            message: "Name content cannot be empty!"
        });
    }

    // Create a new Customer (using schema)
    const customer = new Customer({
        fname: req.body.fname,
        lname: req.body.lname,
        email: req.body.email,
        mobile: req.body.mobile,
        address: req.body.address,
        ShipAdd: req.body.ShipAdd
    });

    // Save Customer in the database
    customer.save()
    .then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while creating the Customer."
        });
    });
};

// Return all Customers in the database
exports.findAll = (req, res) => {
    Customer.find()
    .then(customer => {
        res.send(customer);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Customers."
        });
    });
};

// Find a single customer identified by first name
exports.findOne = (req, res) => {
    Customer.findById(req.params.fname)
    .then(customer => {
        if(!customer) {
            return res.status(404).send({
                message: "Quotation not found with first name " + req.params.fname
            });            
        }
        res.send(customer);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Quotation not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error retrieving Quotation with first name " + req.params.fname
        });
    });
};

// Update a customer identified by the first name in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "Customer content cannot be empty"
        });
    }

    // Find the customer and update it with the request body
    Customer.findByIdAndUpdate(req.params.fname, {
        fname: req.body.fname, 
        lname: req.body.lname,
        email: req.body.email,
        mobile: req.body.mobile,
        address: req.body.address,
        ShipAdd: req.body.ShipAdd,
    }, 
       { new: true })  // "new: true" return updated object
    .then(customer => {
        if(!customer) {
            return res.status(404).send({
                message: "Customer not found with first name " + req.params.fname
            });
        }
        res.send(customer);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "customer not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error updating Customer with first name " + req.params.fname
        });
    });
};

// Update a customer identified by the first name in the request
exports.updateCust = (req, res) => {
    // Validate Request
    if(!req.body.customer) {
        return res.status(400).send({
            message: "Customer content cannot be empty"
        });
    }

    // Find the customer and update it with the request body
    Customer.findByIdAndUpdate(req.params.fname, {
        fname: req.body.fname
    }, 
       { new: true })  // "new: true" return updated object
    .then(customer => {
        if(!customer) {
            return res.status(404).send({
                message: "Customer not found with first name " + req.params.fname
            });
        }
        res.send(customer);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Customer not found with first name " + req.params.fname
            });                
        }
        return res.status(500).send({
            message: "Error updating Customer with first name " + req.params.fname
        });
    });
};



// Delete a customer identified by customerId
exports.delete = (req, res) => {
    Customer.findByIdAndRemove(req.params.customerId)
    .then(customer => {
        if(!customer) {
            return res.status(404).send({
                message: "Customer not found with id " + req.params.customerId
            });
        }
        res.send({message: "Customer deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Customer not found with id " + req.params.customerId
            });                
        }
        return res.status(500).send({
            message: "Could not delete Customer with id " + req.params.customerId
        });
    });
};