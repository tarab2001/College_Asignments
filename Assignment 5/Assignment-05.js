
//This code is based off code given to us by John
// 
//
const MongoClient = require('mongodb').MongoClient;
const assert = require('assert');
const connect = require("./connect");       // url from connect module
//const connect = require("./connect_atlas"); // url from connect module
const client = new MongoClient(connect.database.url, { useUnifiedTopology: true } );

// database name
const dbName = 'Assignment5';

// Use connect method to connect to the server
client.connect(function(err) {
  // using the assert module for testing
  assert.equal(null, err);
  console.log("Connected successfully to server");

  // use this database
  const db = client.db(dbName);



///* uncomment this to find customers after updating custumers after inserting custumers
insertCustomers(db, function() {
    updateCustomers(db, function() {
          findCustomersFiltered(db,function(){
            client.close();
          });
        });
    });
///* unncomment this to find phones after updating phone after inserting phone
/*insertPhone(db, function() {
  updatePhone(db, function() {
        findPhoneFiltered(db,function(){
          client.close();
        });
      });
  });*/

///* uncomment thid to find order after updating order after inserting order
/*insertOrder(db, function() {
  updateOrder(db, function() {
        findOrderFiltered(db,function(){
          client.close();
        });
      });
  });*/


///*uncomment this to remove customer
/* removeCustomers(db,function(){
  client.close();
});
*/
///*uncomment this to remove phone
/* removePhone(db,function(){
  client.close();
});
*/

///*uncomment this to remove order
/* removeOrder(db,function(){
  client.close();
});
*/

});






//C(reate)
// insertCustomers() : insert three documents in to "CustDets"
//                     collection (created if it does not exist)
//
const insertCustomers = function(db, callback) {
  // Using the "CustDets" collection
  const collection = db.collection('CustDets');
  // Insert some customers
  collection.insertMany([
    {"title" : "Ms", "fname":"Alondra","lname":"Dunne","email":"alondra.dunne@purplemail.ie","mobile":"0849937354",
    address:{"AddressLine1":"23 Mayo Rd.","AddressLine2":"Riverside","Town":"Tipperary town","cityOrCounty":"Tipperary", "Eircode": "RT67UJ9"},
    ShipAdd:{"ShipLine1":"23 Mayo Rd.","ShipLine2":"Riverside","Town":"Tipperary town","cityOrCounty":"Tipperary", "Eircode" : "RT67UJ9"}},
    {"title" : "Dr", "fname":"Iarlaith","lname":"Kelly","email":"iarlaith.kelly@fuchsiamail.ie","mobile":"0843977120",
    address:{"AddressLine1":"56 Moyglare Avenue","AddressLine2":"Yellow Road","Town":"Portumna","cityOrCounty":"Galway", "Eircode" : "GH67U99"},
    ShipAdd:{"ShipLine1":"56 Moyglare Avenue","ShipLine2":"Yellow Road","Town":"Portumna","cityOrCounty":"Galway", "Eircode" : "GH67U99"}}, 
    {"title" : "Mrs", "fname":"Brigid","lname":"Flynn","email":"brigid.flynn@silvermail.ie","mobile":"0844020733",
    address:{"AddressLine1":"Castletown House","AddressLine2":"","Town":"Celbridge","cityOrCounty":"Kildare", "Eircode" : "W45TH7"},
    ShipAdd:{"ShipLine1":"Castletown House","ShipLine2":"","Town":"Celbridge","cityOrCounty":"Kildare", "Eircode" : "W45TH7"}}
  ], function(err, result) {
    // using the assert module for testing
    assert.equal(err, null);
    assert.equal(3, result.result.n);
    assert.equal(3, result.ops.length);
    // worked if we get to here
    console.log("Inserted 3 customers into the collection");
    callback(result);
  });
}
//
// insertPhone() : insert three phones in to "PhoneDets"
//                     collection (created if it does not exist)
//
const insertPhone = function(db, callback) {
  // Using the "PhoneDets" collection
  const collection = db.collection('PhoneDets');
  // Insert some phones
  collection.insertMany([
    {"manufactuer" : "Apple", "model":"IPhone 12 Pro Max","price":"1299.99"},
    {"manufactuer" : "Apple", "model":"IPhone 8 Max","price":"399.99"},
    {"manufactuer" : "Samsung", "model":"Samsung Galaxy S20","price":"299.99"}
  ], function(err, result) {
    // using the assert module for testing
    assert.equal(err, null);
    assert.equal(3, result.result.n);
    assert.equal(3, result.ops.length);
    // worked if reach here
    console.log("Inserted 3 phones into the collection");
    callback(result);
  });
}
//
// insertOrder() : insert three documents in to "OrderDets"
//                     collection (created if it does not exist)
//
const insertOrder = function(db, callback) {
  // Using the "OrderDets" collection
  const collection = db.collection('OrderDets');
  // Insert some orders
  collection.insertOne([
    {"user_id":"60770ecbd458783898bb7677","phone_id":"60771fa56a358e3c83fd2dfc"}
  ], function(err, result) {
    // using the assert module for testing
    assert.equal(err, null);
    assert.equal(3, result.result.n);
    assert.equal(3, result.ops.length);
    // works if reach here
    console.log("Inserted 1 order into the collection");
    callback(result);
  });
}



//R(etrieve)
// findCustomersFiltered() : find customers in the "CustDets"
//                           collection (assuming it exists) using filter
//
const findCustomersFiltered = function(db, callback) {
    // Get the custDets collection
    const collection = db.collection('CustDets');
    // Find some customers - with a filter
    collection.find({'lname': 'Dunne'}).toArray(function(err, docs) {
      // using the assert module for testing
      assert.equal(err, null);
      console.log("Found the following records");
      // works if reach here
      console.log(docs);
      callback(docs);
    });
} 

//
// findPhoneFiltered() : find phones in the "PhoneDets"
//                           collection (assuming it exists) using filter
//
const findPhoneFiltered = function(db, callback) {
  // Get the phoneDets collection
  const collection = db.collection('PhoneDets');
  // Find some phones - with a filter
  collection.find({'model': 'IPhone XS'}).toArray(function(err, docs) {
    // using the assert module for testing
    assert.equal(err, null);
    console.log("Found the following records");
    // works if reach here
    console.log(docs);
    callback(docs);
  });
} 
//
// findOrderFiltered() : find order in the "OrderDets"
//                           collection (assuming it exists) using filter
//
const findOrdersFiltered = function(db, callback) {
  // Get the orderDets collection
  const collection = db.collection('OrderDets');
  // Find some orders - with a filter
  collection.find({"phone_id" : "60771fa56a358e3c83fd2dfc"}).toArray(function(err, docs) {
    // using the assert module for testing
    assert.equal(err, null);
    console.log("Found the following records");
    // works if reach here
    console.log(docs);
    callback(docs);
  });
} 

//U(pdate)
// updateCustomers() : update customer in the "CustDets"
//                    collection (assuming it exists)
//
const updateCustomers = function(db, callback) {
    // Get the custDets collection
    const collection = db.collection('CustDets');
    // Update customer where email is "alondra.dunne@purplemail.ie", set to "alondra.dunne@gmail.com"
    collection.updateOne({email : "alondra.dunne@purplemail.ie" }
      , { $set: { email :  "alondra.dunne@gmail.com", mobile : "0891234567", title: "Mrs" } }, function(err, result) {
      // using the assert module for testing
      assert.equal(err, null);
      assert.equal(0, result.result.n);
      // all good if we get to here
      console.log("Updated the document: reset email field set to alondra.dunne@gmail.com, mobile to 0883451289 and tutle to Mrs");
      callback(result);
    });  
  }

//
// updatePhone() : update phone in the "PhoneDets"
//                    collection (assuming it exists)
//
const updatePhone = function(db, callback) {
  // Get the phoneDets collection
  const collection = db.collection('PhoneDets');
  // Update phone where manufactuer is Nokia, set price to 40.99
  collection.updateOne({"Manufactuer" : "Nokia" }
    , { $set: { "Price" :  "40.99" } }, function(err, result) {
    // using the assert module for testing
    assert.equal(err, null);
    assert.equal(0, result.result.n);
    // all good if we get to here
    console.log("Updated the phone: reset price field set to 40.99");
    callback(result);
  });  
}

//
// updateOrder() : update customer in the "CustDets"
//                    collection (assuming it exists)
//
const updateOrder = function(db, callback) {
  // Get the orderDets collection
  const collection = db.collection('OrderDets');
  // Update order where id is "60771e236a358e3c83fd2dfb", set to phone_id to  "60771fe4d458783898bb7679"
  collection.updateOne({"user_id" : "60770ecbd458783898bb7677" }
    , { $set: { phone_id :  "60771fe4d458783898bb7679" } }, function(err, result) {
    // using the assert module for testing
    assert.equal(err, null);
    assert.equal(0, result.result.n);
    // all good if we get to here
    console.log("Updated the order: reset phoneID field to 60771fe4d458783898bb7679");
    callback(result);
  });  
}

//D(elete)
// removeCustomers() : remove customers in the "CustDets"
//                    collection (assuming it exists)
//
const removeCustomers = function(db, callback) {
    // Get the custdets collection
    const collection = db.collection('CustDets');
    // Delete customer where email is "taracuffe@gmail.com"
    collection.deleteOne({ email : "taracuffe@gmail.com" }, function(err, result) {
      // using the assert module for testing
      assert.equal(err, null);
      assert.equal(1, result.result.n);
      // all good if we get to here      
      console.log("Removed the customer with email : 'taracuffe@gmail.com'");
      callback(result);
    });    
}

//
// removePhone() : remove phone in the "PhoneDets"
//                    collection (assuming it exists)
//
const removePhone = function(db, callback) {
  // Get the phoneDets collection
  const collection = db.collection('PhoneDets');
  // Delete phone where model is "Samsung Galaxy S20"
  collection.deleteOne({ "model" : "Samsung Galaxy S20" }, function(err, result) {
    // using the assert module for testing
    assert.equal(err, null);
    assert.equal(1, result.result.n);
    // all good if we get to here      
    console.log("Removed the phone with model : Samsung Galaxy S20");
    callback(result);
  });    
}

//
// removeOrder() : remove order in the "OrderDets"
//                    collection (assuming it exists)
//
const removeOrder = function(db, callback) {
  // Get the orderDets collection
  const collection = db.collection('OrderDets');
  // Delete order where id is "607720ecd458783898bb767c"
  collection.deleteOne({ "_id" : "607720ecd458783898bb767c" }, function(err, result) {
    // using the assert module for testing
    assert.equal(err, null);
    assert.equal(1, result.result.n);
    // all good if we get to here      
    console.log("Removed the order with ID : 607720ecd458783898bb767c ");
    callback(result);
  });    
}

//my database design is as follows: 
// I have a customer collection called CustDets this contains the customers title,first name(fname), last name(lname), email address(email),
// phone number(phone) and their shipping (ShippAdd) and billing address(address)
// There is a phone collection called PhoneDets this contains the model and make of the phone and the price
// The last collection is for the orders called OrderDets this contsiains an orderID along with the phoneId and customerId who is buying 
//the phone