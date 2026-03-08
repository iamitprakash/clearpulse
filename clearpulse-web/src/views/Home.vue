<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { usePulseStore } from '../stores/pulseStore'
import { PlusCircle, History, Zap, Shield, MessageSquare, ArrowRight } from 'lucide-vue-next'

const title = ref('')
const store = usePulseStore()
const router = useRouter()
const isCreating = ref(false)

const createPulse = async () => {
  if (!title.value) return
  isCreating.value = true
  try {
    const token = await store.createPulse(title.value)
    router.push(`/manage/${token}`)
  } finally {
    isCreating.value = false
  }
}

const features = [
  {
    icon: Shield,
    title: 'Absolute Privacy',
    desc: 'No IP logging, no tracking, no identity. Pure anonymous voice.'
  },
  {
    icon: MessageSquare,
    title: 'Honest Insights',
    desc: 'Get the feedback people are afraid to give in person.'
  },
  {
    icon: Zap,
    title: 'Instant Setup',
    desc: 'No accounts. Create a Pulse and start receiving feedback in seconds.'
  }
]
</script>

<template>
  <div class="pt-20 pb-32">
    <!-- Hero Section -->
    <section class="max-w-7xl mx-auto px-6 text-center mb-24">
      <!-- Pulse Mascot -->
      <div class="flex justify-center mb-8 animate-reveal">
        <svg viewBox="0 0 200 200" class="w-24 h-24 md:w-32 md:h-32 animate-float drop-shadow-[0_0_30px_rgba(61,104,243,0.3)]">
          <circle cx="100" cy="100" r="80" fill="url(#pulse-grad)" />
          <circle cx="70" cy="85" r="8" fill="white" />
          <circle cx="130" cy="85" r="8" fill="white" />
          <path d="M 75 130 Q 100 155 125 130" stroke="white" stroke-width="8" fill="none" stroke-linecap="round" />
          <defs>
            <linearGradient id="pulse-grad" x1="0%" y1="0%" x2="100%" y2="100%">
              <stop offset="0%" style="stop-color:var(--color-brand-600)" />
              <stop offset="100%" style="stop-color:var(--color-brand-400)" />
            </linearGradient>
          </defs>
        </svg>
      </div>

      <h1 class="text-6xl md:text-8xl font-display font-extrabold tracking-tighter mb-8 leading-[1.1] animate-reveal">
        Empower Your Voice.<br />
        <span class="text-brand-500">Anonymously.</span>
      </h1>
      <p class="text-xl md:text-2xl text-slate-400 max-w-3xl mx-auto mb-12 leading-relaxed animate-reveal [animation-delay:200ms]">
        The safe space for honest feedback and insights. <br class="hidden md:block" />
        No identity, no tracking—just pure communication.
      </p>
      
      <!-- Create Pulse Card -->
      <div class="max-w-xl mx-auto glass-card p-2 md:p-3 animate-reveal [animation-delay:400ms]">
        <div class="flex flex-col md:flex-row gap-3">
          <input 
            v-model="title"
            placeholder="What's your Pulse for?"
            class="flex-1 glass-input !py-4"
            @keyup.enter="createPulse"
          />
          <button 
            @click="createPulse"
            :disabled="isCreating || !title"
            class="btn-primary min-w-[180px] disabled:opacity-50 disabled:cursor-not-allowed"
          >
            <PlusCircle :size="20" />
            <span>{{ isCreating ? 'Creating...' : 'Start Pulse' }}</span>
          </button>
        </div>
      </div>
    </section>

    <!-- Features Grid -->
    <section class="max-w-7xl mx-auto px-6 grid md:grid-cols-3 gap-8 mb-32">
      <div 
        v-for="(f, i) in features" 
        :key="i"
        class="glass-card p-10 hover:border-white/20 transition-all group animate-reveal"
        :style="{ animationDelay: `${(i + 1) * 150}ms` }"
      >
        <div class="w-16 h-16 glass flex items-center justify-center mb-8 group-hover:bg-brand-500/10 transition-all animate-float" :style="{ animationDelay: `${i * 500}ms` }">
          <component :is="f.icon" class="text-brand-400" :size="32" />
        </div>
        <h3 class="text-2xl font-display font-bold text-white mb-4">{{ f.title }}</h3>
        <p class="text-slate-400 leading-relaxed text-lg">{{ f.desc }}</p>
      </div>
    </section>

    <!-- Recent Pulses -->
    <section v-if="store.recentPulses.length" class="max-w-3xl mx-auto px-6 animate-fade-in">
      <div class="flex items-center justify-between mb-8">
        <h3 class="text-sm font-bold text-slate-500 uppercase tracking-widest flex items-center gap-3">
          <History :size="18" />
          Recent Management Access
        </h3>
      </div>
      <div class="grid gap-4">
        <router-link 
          v-for="p in store.recentPulses" 
          :key="p.token"
          :to="`/manage/${p.token}`"
          class="glass-card p-6 hover:bg-white/5 transition-all flex justify-between items-center group"
        >
          <div>
            <h4 class="text-lg font-bold text-white group-hover:text-brand-400 transition-colors">{{ p.title }}</h4>
            <span class="text-sm text-slate-500">Created {{ new Date(p.createdAt).toLocaleDateString() }}</span>
          </div>
          <ArrowRight class="text-slate-600 group-hover:translate-x-1 group-hover:text-brand-400 transition-all" :size="20" />
        </router-link>
      </div>
    </section>
  </div>
</template>
