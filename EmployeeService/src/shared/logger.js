/**
 * Logger utility for structured logging across the application
 * Provides methods for different log levels: debug, info, warn, error
 * Logs to both console and server.log file
 */

const fs = require('fs');
const path = require('path');
const config = require('../config/config');

// Ensure logs directory exists
const logsDir = path.join(__dirname, '../../logs');
if (!fs.existsSync(logsDir)) {
  fs.mkdirSync(logsDir, { recursive: true });
}

const logFilePath = path.join(logsDir, 'execution.log');

class Logger {
  constructor(context = 'App') {
    this.context = context;
    this.logLevel = config.logLevel || 'info';
  }

  /**
   * Get current timestamp in ISO format
   */
  getTimestamp() {
    return new Date().toISOString();
  }

  /**
   * Format log message with context and timestamp
   */
  formatMessage(level, message, data = null) {
    const timestamp = this.getTimestamp();
    const logData = data ? ` | ${JSON.stringify(data)}` : '';
    return `[${timestamp}] [${level}] [${this.context}] ${message}${logData}`;
  }

  /**
   * Write log to file
   */
  writeToFile(message) {
    try {
      fs.appendFileSync(logFilePath, message + '\n', 'utf8');
    } catch (err) {
      console.error('Failed to write to log file:', err);
    }
  }

  /**
   * Debug level logging
   */
  debug(message, data = null) {
    if (this.logLevel === 'debug') {
      const formatted = this.formatMessage('DEBUG', message, data);
      console.log(formatted);
      this.writeToFile(formatted);
    }
  }

  /**
   * Info level logging
   */
  info(message, data = null) {
    const formatted = this.formatMessage('INFO', message, data);
    console.log(formatted);
    this.writeToFile(formatted);
  }

  /**
   * Warn level logging
   */
  warn(message, data = null) {
    const formatted = this.formatMessage('WARN', message, data);
    console.warn(formatted);
    this.writeToFile(formatted);
  }

  /**
   * Error level logging
   */
  error(message, err = null) {
    let formatted;
    if (err instanceof Error) {
      formatted = this.formatMessage('ERROR', message, {
        message: err.message,
        stack: err.stack
      });
    } else {
      formatted = this.formatMessage('ERROR', message, err);
    }
    console.error(formatted);
    this.writeToFile(formatted);
  }

  /**
   * Log method entry
   */
  methodEntry(methodName, params = null) {
    this.debug(`>> ${methodName}`, params);
  }

  /**
   * Log method exit
   */
  methodExit(methodName, result = null) {
    this.debug(`<< ${methodName}`, result);
  }
}

module.exports = Logger;

