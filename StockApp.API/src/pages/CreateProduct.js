import React from 'react';
import { Container, Typography } from '@material-ui/core';
import { useNavigate } from 'react-router-dom';
import ProductForm from '../components/ProductForm';
import { createProduct } from '../services/api';

const CreateProduct = () => {
    const navigate = useNavigate();

    const handleSubmit = async (product) => {
        try {
            await createProduct(product);
            navigate('/products');
        } catch (error) {
            console.error('Error creating product:', error);
        }
    };

    return (
        <Container>
            <Typography variant="h2" component="h1" gutterBottom>
                Create New Product
            </Typography>
            <ProductForm onSubmit={handleSubmit} />
        </Container>
    );
};

export default CreateProduct;