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
  <div v-if="store.currentPulse" class="max-w-5xl mx-auto py-16 px-6 relative z-10 animate-fade-in">
    <div class="flex flex-col md:flex-row justify-between items-start gap-8 mb-12">
      <div>
        <h1 class="text-4xl md:text-5xl font-display font-extrabold text-white tracking-tight mb-3">
          {{ store.currentPulse.title }}
        </h1>
        <p class="text-slate-400 flex items-center gap-2 font-medium">
          <Clock :size="16" class="text-brand-400" />
          Created on {{ new Date(store.currentPulse.createdAt).toLocaleDateString() }}
        </p>
      </div>
      
      <div class="flex gap-4 w-full md:w-auto">
        <button 
          @click="copyLink"
          class="btn-primary !py-3 !px-6 text-sm flex-1 md:flex-none"
        >
          <component :is="isCopied ? CheckCircle : Copy" :size="18" />
          <span>{{ isCopied ? 'Copied URL' : 'Copy Share Link' }}</span>
        </button>
      </div>
    </div>

    <div class="grid lg:grid-cols-12 gap-8">
      <!-- Sidebar / Info -->
      <div class="lg:col-span-4 space-y-6">
        <div class="glass-card p-8 border-l-4 border-l-brand-500">
          <div class="flex gap-4 mb-4 text-brand-400">
            <Share2 :size="24" />
            <h3 class="font-bold text-white uppercase tracking-wider text-sm mt-1">Share this Pulse</h3>
          </div>
          <p class="text-slate-400 text-sm mb-6 leading-relaxed">
            Only you can accessed this dashboard. Share the public link below to receive anonymous responses.
          </p>
          <div class="relative">
            <code class="block w-full p-4 glass bg-black/20 rounded-xl text-xs font-mono text-brand-300 break-all border border-white/5">
              {{ origin }}/p/{{ store.currentPulse.publicId }}
            </code>
          </div>
        </div>

        <div class="glass-card p-8">
          <h3 class="font-bold text-white uppercase tracking-wider text-sm mb-4">Pulse Analytics</h3>
          <div class="grid grid-cols-2 gap-4">
            <div class="p-4 glass bg-white/5 rounded-2xl text-center">
              <div class="text-2xl font-bold text-white">{{ store.feedbacks.length }}</div>
              <div class="text-[10px] text-slate-500 uppercase font-bold tracking-widest mt-1">Responses</div>
            </div>
            <div class="p-4 glass bg-white/5 rounded-2xl text-center">
              <div class="text-2xl font-bold text-white">{{ store.currentPulse.views }}</div>
              <div class="text-[10px] text-slate-500 uppercase font-bold tracking-widest mt-1">Views</div>
            </div>
          </div>
        </div>
      </div>

      <!-- Feedbacks List -->
      <div class="lg:col-span-8 space-y-6">
        <div class="flex items-center justify-between mb-2">
          <h2 class="text-2xl font-display font-bold text-white flex items-center gap-3">
            <MessageSquare :size="24" class="text-brand-400" />
            Responses
          </h2>
        </div>
        
        <div v-if="store.feedbacks.length === 0" class="glass-card p-20 text-center">
          <div class="w-16 h-16 glass mx-auto mb-6 flex items-center justify-center text-slate-600">
            <MessageSquare :size="32" />
          </div>
          <p class="text-slate-400 font-medium italic">No responses yet. The silence is golden, but honesty is better.</p>
        </div>

        <div 
          v-for="(f, i) in store.feedbacks" 
          :key="f.createdAt" 
          class="glass-card p-8 animate-slide-up"
          :style="{ animationDelay: `${i * 100}ms` }"
        >
          <p class="text-lg text-slate-200 whitespace-pre-wrap leading-relaxed mb-6">{{ f.content }}</p>
          <div class="flex justify-between items-center opacity-40 group-hover:opacity-100 transition-opacity">
            <div class="h-[1px] flex-1 bg-white/10 mr-4"></div>
            <span class="text-[10px] font-bold text-slate-400 uppercase tracking-widest">{{ new Date(f.createdAt).toLocaleString() }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div v-else class="flex justify-center py-20">
    <div class="animate-pulse text-slate-400 font-medium tracking-widest uppercase">Loading Pulse...</div>
  </div>
</template>
