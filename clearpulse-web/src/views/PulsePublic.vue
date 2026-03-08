<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import { usePulseStore } from '../stores/pulseStore'
import { Send, ShieldCheck, Heart } from 'lucide-vue-next'

const route = useRoute()
const store = usePulseStore()
const publicId = route.params.id as string

const content = ref('')
const isSubmitting = ref(false)
const isSubmitted = ref(false)
const pulseDetails = ref<any>(null)

onMounted(async () => {
  pulseDetails.value = await store.fetchPublicPulse(publicId)
})

const submit = async () => {
  if (!content.value || content.value.length < 5) return
  isSubmitting.value = true
  try {
    await store.submitFeedback(publicId, content.value)
    isSubmitted.value = true
  } finally {
    isSubmitting.value = false
  }
}
</script>

<template>
  <div class="max-w-xl mx-auto py-20 px-4">
    <div v-if="!isSubmitted">
      <div class="text-center mb-10">
        <h1 class="text-3xl font-bold text-slate-900 mb-2">Give Anonymous Feedback</h1>
        <p v-if="pulseDetails" class="text-slate-500">For: <span class="font-semibold text-slate-700">{{ pulseDetails.title }}</span></p>
      </div>

      <div class="glass p-8">
        <textarea 
          v-model="content"
          placeholder="What's on your mind? Be honest, it's totally anonymous."
          class="w-full h-40 px-4 py-3 rounded-xl border-slate-200 outline-none focus:ring-2 focus:ring-safe-400 transition-all bg-white/50 resize-none mb-4"
        ></textarea>
        
        <div class="flex items-center justify-between">
          <div class="flex items-center gap-2 text-emerald-600 text-sm font-medium">
            <ShieldCheck :size="18" />
            Identity hidden
          </div>
          <button 
            @click="submit"
            :disabled="isSubmitting || content.length < 5"
            class="bg-safe-600 text-white font-semibold px-6 py-2 rounded-xl hover:bg-safe-700 transition-all disabled:opacity-50 flex items-center gap-2"
          >
            {{ isSubmitting ? 'Sending...' : 'Send Feedback' }}
            <Send :size="18" />
          </button>
        </div>
      </div>

      <p class="text-center text-xs text-slate-400 mt-8 leading-relaxed">
        Your feedback is processed securely. We do not store your IP address,<br/> browser fingerprint, or any identifying information.
      </p>
    </div>

    <div v-else class="glass p-12 text-center animate-in zoom-in fade-in duration-500">
      <div class="w-20 h-20 bg-emerald-100 text-emerald-600 rounded-full flex items-center justify-center mx-auto mb-6">
        <Heart :size="40" fill="currentColor" />
      </div>
      <h2 class="text-2xl font-bold text-slate-900 mb-4">Feedback Sent!</h2>
      <p class="text-slate-600 mb-8">Thank you for your honesty. Your voice has been heard anonymously.</p>
      <router-link to="/" class="text-safe-600 font-semibold hover:underline">Start your own Pulse</router-link>
    </div>
  </div>
</template>
