//crrate and save new orders
exports.create = (req, res) => {
    //vaidate request
    if(!req.body.content) {
        return res.status(400).send({
            message: "Order content can't be empty!"
        });
    }

    const OrderDets = new OrderDets({
        _id : require.body._id,
        user_id: require.body.user_id,
        phone_id: require.body.phone_id
    });

    //save oreders iin db
    OrderDets.save().then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send ({
            message: err.message || "An error occured while creating order"
        });
    });
};

//retieve and return single orders from db
exports.findOne = (req,res) => {
    OrderDets.findById(req.params._id).then(OrderDets => {
        if(!OrderDets) {
            return res.status(404).send({
                message: "Order with id " + req.params._id + " not found"
            });
        }
        res.send(OrderDets);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Order with id " + req.params._id + " not found"
            });
        }
        return res.status(500).send({
            message: "Error retrieving order with ID " + req.params._id 
        });
    });
};

//update orders by id
exports.updateOrder = (req, res) => {
    //validate 
    if(!req.body.Orders) {
        return res.status(400).send({
            message: "Orders content can't be empty"
        });
    }
    OrderDets.findByIdAndUpdate(req.parama._id, {
        OrderDets: req.body.OrderDets
    },
    {new:true}).then(OrderDets => {
        if(!OrderDets){
            return res.status(404).send({
                message: "Order with id " + req.params._id + " not found"
            });
        }
        return res.status(500).send({
            message: "Error updating oreder with ID " + req.params._id
        });
    });
};

//delete order with ID
exports.delete = (req, res) => {
    OrderDets.findByIdAndDelete(req.params._id).then(OrderDets => {
        if(!OrderDets){
            return res.status(404).send({
            message: "Orders with id " + req.params._id + " not found"
        });
    }
    res.send({message: "Order deleted successfully!"});

    }).catch(err => {
    if(err.kind === 'ObjectId' || err.name=== 'NotFound'){
        return res.status(404).send({
            message: "Order with id " + req.params._id + " not found"
        });
    }
    return res.status(500).semd({
        message: "Couldn't delete order with id " + req.params._id
    });
  });
}