import { useState, useEffect } from "react";
import MUIDataTable from "mui-datatables";
import axios from "axios";
import { makeStyles } from '@material-ui/core/styles';
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Fade from '@material-ui/core/Fade';
import Backdrop from '@material-ui/core/Backdrop';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Modal from "@mui/material/Modal";
import Input from '@mui/material/Input';
import InputLabel from '@mui/material/InputLabel';
import InputAdornment from '@mui/material/InputAdornment';
const useStyles = makeStyles(theme => ({
  modal: {
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'center',
  },
  paper: {
      backgroundColor: theme.palette.background.paper,
      border: '2px solid #000',
      boxShadow: theme.shadows[5],
      padding: theme.spacing(2, 4, 3),
  },
  colored: {
    backgroundColor: '#FF0000',
    color: '#FFFFFF',
    padding: '5px'
  },
  colorgreen: {
    backgroundColor: '#008000',
    color: '#FFFFFF',
    padding: '5px'
  }
}));
  
export const TableCustomer = () => {
//1 - configuramos Los hooks
const classes = useStyles();
const [customers, setCustomer] = useState( [] )
const [orders, setorders] = useState( [] )
const [openForm, setFormOpen] = useState(false);
const [openOrders, setopenOrders] = useState(false);
const [customSelectedOrders, setSelectedOrders] = useState("");
const [customSelectedCreate, setcustomSelectedCreate] = useState("");
const [customSelectedOrdersId, setSelectedOrdersId] = useState(0);
const [customSelectedCreateId, setcustomSelectedCreateId] = useState(0);
const endpointgetData = 'http://localhost:5153/api/Customer/Listall';

const handleFormOpen = () => {
    setFormOpen(true);
};
const handleFormClose = () => {
    setFormOpen(false);
};
const handleOrdersOpen = () => {
  setopenOrders(true);
};
const handleOrdersClose = () => {
  setopenOrders(false);
};
//2 - fcion para mostrar los datos con axios

const getData = async () => {

    await axios.get(endpointgetData).then((response) => {
        const data = response.data
        setCustomer(data.response)
    })
}

const getOrder = async (Id) => {
  const endpointgetOrder = 'http://localhost:5153/api/Orders/Order'
  console.log(endpointgetOrder)
  await axios.get(endpointgetOrder,
    {
      params: {
        custId: Id
      }
    }
    ).then((response) => {
      const data = response.data
      setorders(data.response)
  })
}

useEffect( ()=>{
    getData()
}, [])

//3 - Definimos las columns
const columnsCustomer = [
    {
        name: "companyname",
        label: "companyname"
    },
    {
        name: "lastOrderDate",
        label: "Last Order Date"
    },
    {
        name: "nextPredictedOrder",
        label: "Next Predicted Order"
    },
    {
        name: "custid",
        options: {
          filter: true,
          customBodyRender: (value, tableMeta, updateValue) => {
            return (
              <Button variant="contained" color="secondary"  onClick={(e) => {
                try {
                  handleOrdersOpen();
                  setSelectedOrders(tableMeta.rowData[0]);
                  setSelectedOrdersId(tableMeta.rowData[3]);
                  getOrder(tableMeta.rowData[3]);
                } catch (err) {
                  console.log(err);
                }
              }}>VIEW ORDERS</Button>
            );

          }
        }
      },
      {
          name: "custid",
          options: {
            filter: true,
            customBodyRender: (value, tableMeta, updateValue) => {
  
              return (
                <Button variant="contained" color="primary"  onClick={(e) => {
                  try {
                    handleFormOpen();
                    setcustomSelectedCreate(tableMeta.rowData[0]);
                    customSelectedCreateId(tableMeta.rowData[3]);
                  } catch (err) {
                    console.log(err);
                  }
                }}>NEW ORDER</Button>
              );
  
            }
          }
        }
]
const columnsorders = [
  {
      name: "orderid",
      label: "Order ID"
  },
  {
      name: "requireddate",
      label: "Require ddate"
  },
  {
      name: "shipname",
      label: "Ship Name"
  },
  {
      name: "shipaddress",
      label: "Ship Address"
  },
  {
      name: "shipcity",
      label: "Ship City"
  }
]

        return (
          <div>
            <MUIDataTable 
            title={"Customers"}
            data={customers}
            columns={columnsCustomer}
            />
            <div>
            <Modal
                aria-labelledby="transition-modal-title"
                aria-describedby="transition-modal-description"
                className={classes.modal}
                open={openOrders}
                onClose={handleOrdersClose}
                closeAfterTransition
                BackdropComponent={Backdrop}
                BackdropProps={{
                    timeout: 500,
                }}
            >
                <Fade in={openOrders}>
                    <div className={classes.paper}>
                        <div className={classes.colored}><h2>{customSelectedOrders} - Orders</h2></div>
                        <p>
                            <MUIDataTable 
                            title={"Order Id"}
                            data={orders}
                            columns={columnsorders}
                            />
                        </p>
                    </div>
                </Fade>
            </Modal>
            <Modal
                aria-labelledby="transition-modal-title"
                aria-describedby="transition-modal-description"
                className={classes.modal}
                open={openForm}
                onClose={handleFormClose}
                closeAfterTransition
                BackdropComponent={Backdrop}
                BackdropProps={{
                    timeout: 500,
                }}
            >
                <Fade in={openForm}>
                    <div className={classes.paper}>
                    <div className={classes.colorgreen}><h2>{customSelectedCreate} - New Order</h2></div>
                        <h2>Order</h2>
                        <p>
                        <Box
                            component="form"
                            fullWidth 
                            sx={{
                              '& .MuiTextField-root': { m: 1 },
                            }}
                            noValidate
                            autoComplete="off"
                          >
                            <div>
                            <TextField
                                id="employee"
                                label="Employee"
                                multiline
                                maxRows={4}
                                variant="standard"
                              />
                              <TextField
                                id="shipper"
                                label="Shipper*"
                                maxRows={4}
                                variant="standard"
                              />
                            </div>
                            <div>
                              <TextField 
                                fullWidth 
                                id="shipName"
                                label="Ship Name*"
                                multiline
                                variant="standard"
                              />
                            </div>
                            <div>
                            <TextField
                                id="shipaddress"
                                label="Ship Address*"
                                multiline
                                maxRows={4}
                                variant="standard"
                              />
                              <TextField
                                id="shipcity"
                                label="Ship City*"
                                maxRows={4}
                                variant="standard"
                              />
                              <TextField
                                id="shipcountry"
                                label="Ship Country*"
                                maxRows={4}
                                variant="standard"
                              />
                            </div>
                            <div>
                              <TextField
                                label="$ Freight*"
                                fullWidth
                                id="standard-adornment-amount"
                                variant="standard"
                              />
                            </div>
                            <h2>Order Details</h2>
                            <div>
                              <TextField
                                label="Product*"
                                fullWidth
                                id="product"
                                variant="standard"
                              />
                            </div>
                            <div>
                            <TextField
                                label="$ Unite Price*"
                                id="unitprice"
                                variant="standard"
                              />
                              <TextField
                                id="quantity"
                                label="Quantity*"
                                maxRows={4}
                                variant="standard"
                              />
                              <TextField
                                id="discount"
                                label="Discount*"
                                maxRows={4}
                                variant="standard"
                              />
                            </div>
                          </Box>
                        </p>
                    </div>
                </Fade>
            </Modal>
        </div>
          </div>
        )

}