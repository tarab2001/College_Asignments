const Order = require('../models/OrderDets.model.js');

// Default message for / (get)
exports.root = (req, res) => {
    Order.find()
    .then(order => {
        res.render('orders_view',{
            results: order
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Orders."
        });
    });
};

// search for orders, matching string on quote field
exports.searchOrderId = (req, res) => {
    var search = req.params.s;
    console.log("Searching OrderId: "+search)
    Order.find({ orderId: new RegExp(search,"ig")})
    .then(order => {
        res.render('orders_view',{
            results: order
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Orders."
        });
    });
};

// search for orders, matching string on quote field
exports.searchPhoneId = (req, res) => {
    var search = req.params.s;
    console.log("Searching phoneId: "+search)
    Order.find({ phoneId: new RegExp(search,"ig")})
    .then(order => {
        res.render('orders_view',{
            results: order
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Orders."
        });
    });
};

// search for orders, matching string on quote field
exports.searchCustomerId = (req, res) => {
    var search = req.params.s;
    console.log("Searching CustomerId: "+search)
    Order.find({ customerId: new RegExp(search,"ig")})
    .then(order => {
        res.render('orders_view',{
            results: order
          });
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Orders."
        });
    });
};

// Create a new Order and save to the database
// Create and Save a new Order
exports.create = (req, res) => {
    // Validate the request
    if(!req.body.orderId || !req.body.phoneId || !req.body.cutomerId) {
        return res.status(400).send({
            message: "Order content cannot be empty!"
        });
    }

    // Create a new order (using schema)
    const order = new Order({
        orderId: req.body.orderId,
        phoneId: req.body.phoneId,
        customerId: req.body.customerId
    });

    // Save Order in the database
    order.save()
    .then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while creating the Order."
        });
    });
};

// Return all Orders in the database
exports.findAll = (req, res) => {
    Order.find()
    .then(order => {
        res.send(order);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "An error occurred while retrieving all Orders."
        });
    });
};

// Find a single Order identified by orderId
exports.findOne = (req, res) => {
    Order.findById(req.params.orderId)
    .then(order => {
        if(!order) {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });            
        }
        res.send(order);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });                
        }
        return res.status(500).send({
            message: "Error retrieving Order with id " + req.params.orderId
        });
    });
};

// Update a order identified by the orderId in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "Order content cannot be empty"
        });
    }

    // Find the order and update it with the request body
    Order.findByIdAndUpdate(req.params.orderId, {
        orderId: req.body.orderId, 
        phoneId: req.body.phoneId,
        customerId: req.body.customerId
    }, 
       { new: true })  // "new: true" return updated object
    .then(order => {
        if(!order) {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });
        }
        res.send(order);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });                
        }
        return res.status(500).send({
            message: "Error updating Order with id " + req.params.orderId
        });
    });
};

// Update a Order identified by the orderId in the request
exports.updateOrder = (req, res) => {
    // Validate Request
    if(!req.body.order) {
        return res.status(400).send({
            message: "Order content cannot be empty"
        });
    }

    // Find the Quotation and update it with the request body
    Order.findByIdAndUpdate(req.params.orderId, {
        orderId: req.body.orderId
    }, 
       { new: true })  // "new: true" return updated object
    .then(order => {
        if(!order) {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });
        }
        res.send(order);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });                
        }
        return res.status(500).send({
            message: "Error updating Order with id " + req.params.orderId
        });
    });
};



// Delete a order identified by orderId
exports.delete = (req, res) => {
    Order.findByIdAndRemove(req.params.orderId)
    .then(order => {
        if(!order) {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });
        }
        res.send({message: "Order deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Order not found with id " + req.params.orderId
            });                
        }
        return res.status(500).send({
            message: "Could not delete Order with id " + req.params.orderId
        });
    });
};