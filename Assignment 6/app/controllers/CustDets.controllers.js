//crrate and save new orders
expots.create = (req, res) => {
    //vaidate request
    if(!req.body.content) {
        return res.status(400).send({
            message: "Customer content can't be empty!"
        });
    }

    const CustDets = new CustDets({
       title: requie.body.title,
       fname: requie.body.fname,
       lname: requie.body.lname,
       email: requie.body.email,
       mobile: requie.body.mobile,
       address: requie.body.address,
       ShipAdd: requie.body.ShipAdd
    });

    //save oreders iin db
    CustDets.save().then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send ({
            message: err.message || "An error occured while creating  customer"
        });
    });
};

//retieve and return single customer from db
exports.findOne = (req,res) => {
    CustDets.findByFname(req.params.fname).then(CustDets => {
        if(!CustDets) {
            return res.status(404).send({
                message: "Customer with first name " + req.params.fname + " not found"
            });
        }
        res.send(CustDets);
    }).catch(err => {
        if(err.kind === 'String') {
            return res.status(404).send({
                message: "Customer with first name " + req.params.fname + " not found"
            });
        }
        return res.status(500).send({
            message: "Error retrieving customer with first name " + req.params._id 
        });
    });
};

//update customer by name
exports.updateCustomer = (req, res) => {
    //validate 
    if(!req.body.CustDets) {
        return res.status(400).send({
            message: "Customers content can't be empty"
        });
    }
    CustDets.findByNameAndUpdate(req.parama.fname, {
        CustDets: req.body.CustDets
    },
    {new:true}).then(CustDets => {
        if(!CustDets){
            return res.status(404).send({
                message: "Customer with fname " + req.params.fname + " not found"
            });
        }
        return res.status(500).send({
            message: "Error updating customer with first name " + req.params.fname
        });
    });
};

//delete order with ID
exports.delete = (req, res) => {
    CustDets.findByNameAndDelete(req.params.fname).then(CustDets => {
        if(!CustDets){
            return res.status(404).send({
            message: "Customer with name " + req.params.fname + " not found"
        });
    }
    res.send({message: "Customer deleted successfully!"});

    }).catch(err => {
    if(err.kind === 'String' || err.name === 'NotFound'){
        return res.status(404).send({
            message: "Customer with name " + req.params.fname + " not found"
        });
    }
    return res.status(500).semd({
        message: "Couldn't delete custumer with name " + req.params.fname
    });
  });
}