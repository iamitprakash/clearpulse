<script setup lang="ts">
import { ShieldAlert, Fingerprint, EyeOff, Database, History, Globe } from 'lucide-vue-next'

const privacyPoints = [
  {
    icon: Fingerprint,
    title: 'No Identity Tracking',
    desc: 'We do not collect IP addresses, browser fingerprints, or device IDs. Your digital footprint remains invisible.'
  },
  {
    icon: EyeOff,
    title: 'Zero Cookies',
    desc: 'Clearpulse does not use tracking cookies or third-party analytics scripts like Google Analytics.'
  },
  {
    icon: Database,
    title: 'Data Minimization',
    desc: 'We only store the content of your Pulse and the feedback received. No metadata, no logs, no baggage.'
  },
  {
    icon: History,
    title: 'Transient Storage',
    desc: 'Pulses are designed to be temporary. You can delete your Pulse and all associated data permanently at any time.'
  },
  {
    icon: ShieldAlert,
    title: 'Encryption at Rest',
    desc: 'All feedback is encrypted before hitting our database. Even in the event of a breach, your data remains unreadable.'
  },
  {
    icon: Globe,
    title: 'Legal Commitment',
    desc: 'We operate under a strict privacy-first mandate. We will never sell your data because we don\'t have any data to sell.'
  }
]
</script>

<template>
  <div class="pt-32 pb-32">
    <div class="max-w-4xl mx-auto px-6">
      <div class="text-center mb-24 animate-reveal">
        <div class="inline-flex items-center justify-center w-20 h-20 glass mb-8 text-brand-400">
          <ShieldAlert :size="40" />
        </div>
        <h1 class="text-5xl md:text-7xl font-display font-extrabold tracking-tighter mb-8">
          Privacy <span class="text-brand-500">Manifesto.</span>
        </h1>
        <p class="text-xl text-slate-400 leading-relaxed italic">
          "Privacy is not a feature; it's a fundamental human right."
        </p>
      </div>

      <div class="space-y-12 mb-24">
        <div 
          v-for="(p, i) in privacyPoints" 
          :key="i"
          class="glass-card p-10 flex flex-col md:flex-row gap-8 items-start animate-reveal"
          :style="{ animationDelay: `${i * 100}ms` }"
        >
          <div class="w-14 h-14 glass flex items-center justify-center shrink-0 text-brand-400 bg-brand-500/5">
            <component :is="p.icon" :size="28" />
          </div>
          <div>
            <h3 class="text-2xl font-display font-bold text-white mb-4">{{ p.title }}</h3>
            <p class="text-slate-400 leading-relaxed text-lg">{{ p.desc }}</p>
          </div>
        </div>
      </div>

      <!-- Tech Stack Note -->
      <div class="glass-card p-12 border-white/5 bg-slate-900/40 animate-reveal">
        <h2 class="text-2xl font-display font-bold text-white mb-6 flex items-center gap-3">
          <Database class="text-brand-400" :size="24" />
          Technical Transparency
        </h2>
        <div class="space-y-4 text-slate-400 leading-relaxed">
          <p>
            Our system is build to ensure strict separation of concerns. 
            The database is designed to prevent "identity leakage" by isolating feedback responses from management tokens.
          </p>
          <p>
            Clearpulse is open-source-minded and follows industry best practices for secure application development.
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
