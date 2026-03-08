<script setup lang="ts">
import { Shield, Zap, MessageSquare, BarChart3, Lock, Users } from 'lucide-vue-next'

const mainFeatures = [
  {
    icon: Shield,
    title: 'Absolute Anonymity',
    desc: 'No IP logging, no cookies, no tracking. We don\'t even want to know who you are.'
  },
  {
    icon: MessageSquare,
    title: 'Honest Feedback',
    desc: 'Create a safe space where people feel comfortable sharing their true thoughts without repercussion.'
  },
  {
    icon: Zap,
    title: 'Zero Latency Pulse',
    desc: 'Create and share a Pulse link in under 10 seconds. No registration, no overhead.'
  },
  {
    icon: BarChart3,
    title: 'Real-time Analytics',
    desc: 'Track view counts and feedback responses with our live management dashboard.'
  },
  {
    icon: Lock,
    title: 'Encrypted Persistence',
    desc: 'All responses are stored using industry-standard encryption and isolated from any identity markers.'
  },
  {
    icon: Users,
    title: 'Public Sharing',
    desc: 'Generate unique, non-guessable identifiers for every Pulse to ensure only intended participants can join.'
  }
]
</script>

<template>
  <div class="pt-32 pb-32">
    <div class="max-w-7xl mx-auto px-6">
      <div class="text-center mb-24 animate-reveal">
        <h1 class="text-5xl md:text-7xl font-display font-extrabold tracking-tighter mb-8 italic">
          Platform <span class="text-brand-500">Capabilities.</span>
        </h1>
        <p class="text-xl text-slate-400 max-w-2xl mx-auto leading-relaxed">
          Clearpulse is engineered from the ground up for the "Voice of Truth".
          Explore the features that make absolute privacy possible.
        </p>
      </div>

      <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-8">
        <div 
          v-for="(f, i) in mainFeatures" 
          :key="i"
          class="glass-card p-10 hover:border-white/20 transition-all group animate-reveal"
          :style="{ animationDelay: `${i * 100}ms` }"
        >
          <div class="w-16 h-16 glass flex items-center justify-center mb-8 group-hover:bg-brand-500/10 transition-all">
            <component :is="f.icon" class="text-brand-400" :size="32" />
          </div>
          <h3 class="text-2xl font-display font-bold text-white mb-4">{{ f.title }}</h3>
          <p class="text-slate-400 leading-relaxed">{{ f.desc }}</p>
        </div>
      </div>
      
      <!-- Call to Action -->
      <div class="mt-32 glass-card p-12 text-center border-brand-500/20 animate-reveal">
        <h2 class="text-3xl md:text-4xl font-display font-bold text-white mb-6">Ready to hear the truth?</h2>
        <p class="text-slate-400 mb-10 max-w-xl mx-auto">Join thousands of users who trust Clearpulse for their anonymous needs.</p>
        <router-link to="/" class="btn-primary inline-flex">
          Create Your First Pulse
        </router-link>
      </div>
    </div>
  </div>
</template>
