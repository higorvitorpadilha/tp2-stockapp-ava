import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5000/api', // Ajuste esta URL para a URL base da sua API
});

export const getProducts = () => api.get('/products');
export const getProduct = (id) => api.get(`/products/${id}`);
export const createProduct = (product) => api.post('/products', product);
export const updateProduct = (id, product) => api.put(`/products/${id}`, product);
export const deleteProduct = (id) => api.delete(`/products/${id}`);
export const getStockReport = () => api.get('/report/stock');
export const getSalesReport = () => api.get('/report/sales');


export default api;