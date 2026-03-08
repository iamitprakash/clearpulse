import { defineStore } from 'pinia';
import { ref } from 'vue';
import axios from 'axios';

const API_BASE = 'http://localhost:5036/api';

export const usePulseStore = defineStore('pulse', () => {
  const recentPulses = ref<any[]>(JSON.parse(localStorage.getItem('recentPulses') || '[]'));
  const currentPulse = ref<any>(null);
  const feedbacks = ref<any[]>([]);

  const createPulse = async (title: string) => {
    const res = await axios.post(`${API_BASE}/Pulse`, { title });
    const token = res.data.secretToken;
    recentPulses.value.push({ title, token, createdAt: new Date() });
    localStorage.setItem('recentPulses', JSON.stringify(recentPulses.value));
    return token;
  };

  const fetchPulseDetails = async (token: string) => {
    const res = await axios.get(`${API_BASE}/Pulse/${token}`);
    currentPulse.value = res.data;
  };

  const fetchPulseFeedbacks = async (token: string) => {
    const res = await axios.get(`${API_BASE}/Feedback/${token}`);
    feedbacks.value = res.data;
  };

  const submitFeedback = async (publicId: string, content: string) => {
    await axios.post(`${API_BASE}/Feedback/${publicId}`, { content });
  };

  const fetchPublicPulse = async (publicId: string) => {
    const res = await axios.get(`${API_BASE}/Pulse/public/${publicId}`);
    return res.data;
  };

  return {
    recentPulses,
    currentPulse,
    feedbacks,
    createPulse,
    fetchPulseDetails,
    fetchPulseFeedbacks,
    submitFeedback,
    fetchPublicPulse
  };
});
