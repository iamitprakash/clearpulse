<template>
  <div class="min-h-screen">
    <nav class="p-6">
      <div class="max-w-6xl mx-auto flex justify-between items-center">
        <router-link to="/" class="text-2xl font-black text-slate-900 tracking-tighter hover:text-safe-600 transition-colors">
          CLEARPULSE
        </router-link>
        <div class="text-xs font-bold text-slate-400 uppercase tracking-widest px-3 py-1 border rounded-full">
          Private Beta v1.0
        </div>
      </div>
    </nav>
    <router-view></router-view>
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
