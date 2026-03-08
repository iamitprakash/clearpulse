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
  <div class="max-w-2xl mx-auto py-24 px-6 relative z-10 animate-fade-in">
    <div v-if="!isSubmitted">
      <div class="text-center mb-12">
        <h1 class="text-4xl md:text-5xl font-display font-extrabold text-white tracking-tight mb-4">
          Give Anonymous Feedback
        </h1>
        <p v-if="pulseDetails" class="text-lg text-slate-400 font-medium">
          For: <span class="text-brand-400 font-bold border-b border-brand-500/30 pb-1">{{ pulseDetails.title }}</span>
        </p>
      </div>

      <div class="glass-card p-10 shadow-2xl shadow-brand-500/10">
        <textarea 
          v-model="content"
          placeholder="What's on your mind? Be honest, it's totally anonymous."
          class="glass-input h-48 resize-none mb-8 text-lg"
        ></textarea>
        
        <div class="flex flex-col sm:flex-row items-center justify-between gap-6">
          <div class="flex items-center gap-3 text-emerald-400 text-sm font-bold uppercase tracking-widest bg-emerald-500/10 px-4 py-2 rounded-full border border-emerald-500/20">
            <ShieldCheck :size="18" />
            Identity Protected
          </div>
          <button 
            @click="submit"
            :disabled="isSubmitting || content.length < 5"
            class="btn-primary w-full sm:w-auto min-w-[200px] disabled:opacity-50 disabled:cursor-not-allowed group"
          >
            <span>{{ isSubmitting ? 'Sending...' : 'Send Feedback' }}</span>
            <Send :size="18" class="group-hover:translate-x-1 group-hover:-translate-y-1 transition-transform" />
          </button>
        </div>
      </div>

      <div class="mt-12 p-6 glass bg-black/20 rounded-2xl border border-white/5">
        <p class="text-center text-[10px] text-slate-500 font-bold uppercase tracking-[0.2em] leading-relaxed">
          Your feedback is processed securely. <br class="md:hidden" />
          No IP logging. No tracking. Pure Communication.
        </p>
      </div>
    </div>

    <div v-else class="glass-card p-16 text-center animate-slide-up shadow-2xl shadow-emerald-500/10">
      <div class="w-24 h-24 glass-card bg-emerald-500/10 border-emerald-500/20 text-emerald-400 rounded-full flex items-center justify-center mx-auto mb-8 animate-blob">
        <Heart :size="48" fill="currentColor" />
      </div>
      <h2 class="text-4xl font-display font-extrabold text-white mb-4">Feedback Sent!</h2>
      <p class="text-xl text-slate-400 mb-10 leading-relaxed">Thank you for your honesty. Your voice has been heard anonymously.</p>
      <router-link to="/" class="btn-primary !bg-white/5 hover:!bg-white/10 !text-white border border-white/10 mx-auto w-fit">
        Start your own Pulse
      </router-link>
    </div>
  </div>
</template>
