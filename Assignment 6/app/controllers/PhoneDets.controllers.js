//create and save new orders
expots.create = (req, res) => {
    //vaidate request
    if(!req.body.content) {
        return res.status(400).send({
            message: "Phone content can't be empty!"
        });
    }

    const PhoneDets = new PhoneDets({
        manufactuer : require.body.manufactuer,
        model: require.body.model,
        price: require.body.price
    });

    //save oreders iin db
    PhoneDets.save().then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send ({
            message: err.message || "An error occured while creating phone"
        });
    });
};

//retieve and return single orders from db
exports.findOne = (req,res) => {
    PhoneDets.findBymodel(req.params.model).then(PhoneDets => {
        if(!PhoneDets) {
            return res.status(404).send({
                message: "Phone with model name " + req.params.model + " not found"
            });
        }
        res.send(PhoneDets);
    }).catch(err => {
        if(err.kind === 'String') {
            return res.status(404).send({
                message: "Phone with model name " + req.params.model + " not found"
            });
        }
        return res.status(500).send({
            message: "Error retrieving phone with model name " + req.params.model 
        });
    });
};

//update orders by id
exports.updatePhone = (req, res) => {
    //validate 
    if(!req.body.PhoneDets) {
        return res.status(400).send({
            message: "Phone content can't be empty"
        });
    }
    PhoneDets.findByModelAndUpdate(req.parama.model, {
        PhoneDets: req.body.PhoneDets
    },
    {new:true}).then(PhoneDets => {
        if(!PhoneDets){
            return res.status(404).send({
                message: "Phone with model name " + req.params.model + " not found"
            });
        }
        return res.status(500).send({
            message: "Error updating phone with model name " + req.params.model
        });
    });
};

//delete order with ID
exports.delete = (req, res) => {
    PhoneDets.findByModelAndDelete(req.params.model).then(PhoneDets => {
        if(!PhoneDets){
            return res.status(404).send({
            message: "Phone with model name " + req.params.model + " not found"
        });
    }
    res.send({message: "Phone deleted successfully!"});

    }).catch(err => {
    if(err.kind === 'String' || err.name=== 'NotFound'){
        return res.status(404).send({
            message: "Phone with model name " + req.params.model + " not found"
        });
    }
    return res.status(500).semd({
        message: "Couldn't delete phone with model name " + req.params.model
    });
  });
}