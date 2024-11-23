import React from 'react';
import { Typography, Container } from '@material-ui/core';

const Home = () => {
    return (
        <Container>
            <Typography variant="h2" component="h1" gutterBottom>
                Welcome to StockApp
            </Typography>
            <Typography variant="body1">
                This is a simple stock management application. Use the navigation menu to manage your products.
            </Typography>
        </Container>
    );
};

export default Home;