<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import { usePulseStore } from '../stores/pulseStore'
import { Share2, MessageSquare, Clock, Copy, CheckCircle } from 'lucide-vue-next'

const route = useRoute()
const store = usePulseStore()
const token = route.params.token as string
const isCopied = ref(false)

onMounted(async () => {
  await store.fetchPulseDetails(token)
  await store.fetchPulseFeedbacks(token)
})

const origin = window.location.origin

const copyLink = () => {
  const link = `${origin}/p/${store.currentPulse.publicId}`
  navigator.clipboard.writeText(link)
  isCopied.value = true
  setTimeout(() => isCopied.value = false, 2000)
}
</script>

<template>
  <div v-if="store.currentPulse" class="max-w-4xl mx-auto py-12 px-4">
    <div class="flex justify-between items-start mb-8">
      <div>
        <h1 class="text-3xl font-bold text-slate-900">{{ store.currentPulse.title }}</h1>
        <p class="text-slate-500 mt-1 flex items-center gap-2">
          <Clock :size="14" />
          Created on {{ new Date(store.currentPulse.createdAt).toLocaleDateString() }}
        </p>
      </div>
      
      <div class="flex gap-4">
        <button 
          @click="copyLink"
          class="bg-white border text-slate-700 px-4 py-2 rounded-xl flex items-center gap-2 hover:bg-slate-50 transition-all font-medium"
        >
          <component :is="isCopied ? CheckCircle : Copy" :size="18" :class="isCopied ? 'text-emerald-500' : ''" />
          {{ isCopied ? 'Copied!' : 'Copy Share Link' }}
        </button>
      </div>
    </div>

    <div class="grid md:grid-cols-12 gap-8">
      <!-- Public URL Warning -->
      <div class="md:col-span-12 glass p-6 border-l-4 border-l-amber-400 bg-amber-50/30">
        <div class="flex gap-4">
          <Share2 class="text-amber-500 shrink-0" />
          <div>
            <h3 class="font-semibold text-amber-900">Share this Pulse</h3>
            <p class="text-sm text-amber-800/80">
              Only you can see this page. Share the link below with others to get anonymous feedback.
            </p>
            <code class="block mt-3 p-2 bg-white/50 rounded border border-amber-200 text-xs break-all">
              {{ origin }}/p/{{ store.currentPulse.publicId }}
            </code>
          </div>
        </div>
      </div>

      <!-- Feedbacks -->
      <div class="md:col-span-12 space-y-6">
        <h2 class="text-xl font-semibold flex items-center gap-2">
          <MessageSquare :size="20" class="text-safe-500" />
          Responses ({{ store.feedbacks.length }})
        </h2>
        
        <div v-if="store.feedbacks.length === 0" class="glass p-12 text-center">
          <p class="text-slate-400">No responses yet. Share the link to start receiving feedback.</p>
        </div>

        <div v-for="f in store.feedbacks" :key="f.createdAt" class="glass p-6 animate-in fade-in slide-in-from-bottom-4">
          <p class="text-slate-800 whitespace-pre-wrap leading-relaxed">{{ f.content }}</p>
          <div class="mt-4 pt-4 border-t border-slate-100 flex justify-end">
            <span class="text-xs text-slate-400">{{ new Date(f.createdAt).toLocaleString() }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div v-else class="flex justify-center py-20">
    <div class="animate-pulse text-slate-400 font-medium tracking-widest uppercase">Loading Pulse...</div>
  </div>
</template>
