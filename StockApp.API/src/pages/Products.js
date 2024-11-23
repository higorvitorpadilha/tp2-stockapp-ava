import React, { useState, useEffect } from 'react';
import { Container, Typography, Button } from '@material-ui/core';
import { Link } from 'react-router-dom';
import ProductList from '../components/ProductList';
import { getProducts, deleteProduct } from '../services/api';

const Products = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        fetchProducts();
    }, []);

    const fetchProducts = async () => {
        try {
            const response = await getProducts();
            setProducts(response.data);
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    };

    const handleDelete = async (id) => {
        try {
            await deleteProduct(id);
            fetchProducts();
        } catch (error) {
            console.error('Error deleting product:', error);
        }
    };

    return (
        <Container>
            <Typography variant="h2" component="h1" gutterBottom>
                Products
            </Typography>
            <Button component={Link} to="/create-product" variant="contained" color="primary" style={{ marginBottom: '1rem' }}>
                Create New Product
            </Button>
            <ProductList products={products} onDelete={handleDelete} />
        </Container>
    );
};

export default Products;