<script setup lang="ts">
import { RouterView } from 'vue-router'
import { ShieldCheck } from 'lucide-vue-next'
</script>

<template>
  <div class="relative min-h-screen overflow-hidden">
    <!-- Animated Background Blobs -->
    <div class="fixed inset-0 z-0">
      <div class="bg-glow w-[500px] h-[500px] bg-brand-500 top-[-100px] right-[-100px] animate-blob"></div>
      <div class="bg-glow w-[600px] h-[600px] bg-indigo-600 bottom-[-200px] left-[-200px] animate-blob animation-delay-2000"></div>
      <div class="bg-glow w-[400px] h-[400px] bg-emerald-500/30 top-1/2 left-1/3 animate-blob animation-delay-4000"></div>
    </div>

    <!-- Navigation -->
    <nav class="relative z-50 border-b border-white/5 bg-slate-950/20 backdrop-blur-md">
      <div class="max-w-7xl mx-auto px-6 h-20 flex items-center justify-between">
        <router-link to="/" class="flex items-center gap-3 group">
          <div class="w-10 h-10 glass flex items-center justify-center group-hover:bg-brand-500/20 transition-all">
            <ShieldCheck class="text-brand-400" :size="24" />
          </div>
          <span class="text-2xl font-display font-bold text-white tracking-tight">Clearpulse</span>
        </router-link>
        
        <div class="flex items-center gap-8 text-sm font-medium text-slate-400">
          <router-link to="/features" class="hover:text-white transition-colors">Features</router-link>
          <router-link to="/privacy" class="hover:text-white transition-colors">Privacy</router-link>
          <router-link to="/" class="bg-white/5 hover:bg-white/10 text-white px-5 py-2.5 rounded-xl border border-white/10 transition-all">
            Get Started
          </router-link>
        </div>
      </div>
    </nav>

    <main class="relative z-10">
      <RouterView />
    </main>

    <!-- Premium Footer -->
    <footer class="relative z-50 border-t border-white/5 bg-slate-950/20 py-16 backdrop-blur-md">
      <div class="max-w-7xl mx-auto px-6 grid md:grid-cols-4 gap-12">
        <div class="col-span-2">
          <div class="flex items-center gap-3 mb-6">
            <ShieldCheck class="text-brand-400" :size="24" />
            <span class="text-2xl font-display font-bold text-white tracking-tight">Clearpulse</span>
          </div>
          <p class="text-slate-500 max-w-sm leading-relaxed mb-6">
            The world's most private feedback platform. Built for trust, anonymity, and honest communication.
          </p>
          <div class="text-xs text-slate-600 font-mono">
            &copy; 2026 Clearpulse System. All Rights Reserved.
          </div>
        </div>
        
        <div>
          <h4 class="text-white font-bold mb-6">Explore</h4>
          <ul class="space-y-4 text-slate-400 text-sm">
            <li><router-link to="/" class="hover:text-white transition-colors">Home</router-link></li>
            <li><router-link to="/features" class="hover:text-white transition-colors">Features</router-link></li>
            <li><router-link to="/privacy" class="hover:text-white transition-colors">Privacy Policy</router-link></li>
          </ul>
        </div>

        <div>
          <h4 class="text-white font-bold mb-6">Status</h4>
          <div class="flex flex-col gap-4">
            <div class="flex items-center gap-2 text-sm text-emerald-500">
              <div class="w-2 h-2 rounded-full bg-emerald-500 animate-pulse"></div>
              Systems Operational
            </div>
            <div class="text-slate-500 text-xs leading-relaxed">
              Encrypted persistence
            </div>
          </div>
        </div>
      </div>
    </footer>
  </div>
</template>

<style>
/* Global fade transition for routes */
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.3s ease;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
</style>
