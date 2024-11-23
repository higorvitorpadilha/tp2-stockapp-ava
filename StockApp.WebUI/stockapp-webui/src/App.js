import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Bar, Line } from 'react-chartjs-2';
import { Chart as ChartJS, CategoryScale, LinearScale, BarElement, PointElement, LineElement, Title, Tooltip, Legend } from 'chart.js';

ChartJS.register(CategoryScale, LinearScale, BarElement, PointElement, LineElement, Title, Tooltip, Legend);

function App() {
    const [stockData, setStockData] = useState(null);
    const [salesData, setSalesData] = useState(null);

    useEffect(() => {
        fetchStockReport();
        fetchSalesReport();
    }, []);

    const fetchStockReport = async () => {
        try {
            const response = await axios.get('http://localhost:5000/api/report/stock');
            const lines = response.data.split('\n').slice(2);
            const data = lines.map(line => {
                const [name, stock] = line.split(':');
                return { name: name.trim(), stock: parseInt(stock.trim()) };
            });
            setStockData(data);
        } catch (error) {
            console.error('Error fetching stock report:', error);
        }
    };

    const fetchSalesReport = async () => {
        try {
            const response = await axios.get('http://localhost:5000/api/report/sales');
            const lines = response.data.split('\n').slice(3);
            const data = lines.map(line => {
                const [date, sales] = line.split(',');
                return { date, sales: parseInt(sales) };
            });
            setSalesData(data);
        } catch (error) {
            console.error('Error fetching sales report:', error);
        }
    };

    const stockChartData = {
        labels: stockData?.map(item => item.name) || [],
        datasets: [
            {
                label: 'Stock Levels',
                data: stockData?.map(item => item.stock) || [],
                backgroundColor: 'rgba(75, 192, 192, 0.6)',
            },
        ],
    };

    const salesChartData = {
        labels: salesData?.map(item => item.date) || [],
        datasets: [
            {
                label: 'Sales',
                data: salesData?.map(item => item.sales) || [],
                borderColor: 'rgb(75, 192, 192)',
                tension: 0.1,
            },
        ],
    };

    return (
        <div className="App">
            <h1>Stock App Reports</h1>
            <div style={{ width: '600px', margin: '20px auto' }}>
                <h2>Stock Levels</h2>
                {stockData && <Bar data={stockChartData} />}
            </div>
            <div style={{ width: '600px', margin: '20px auto' }}>
                <h2>Sales Report</h2>
                {salesData && <Line data={salesChartData} />}
            </div>
        </div>
    );
}

export default App;